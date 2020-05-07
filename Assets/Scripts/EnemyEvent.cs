using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyEvent : GameEvent
{
	public EnemyTrigger[] Enemies;

	private List<GameObject> _enemies;

	private float orbitSpeed = 5f;

	protected override void Awake()
	{
		base.Awake();
		_enemies = new List<GameObject>();
	}

	protected override void Start()
	{
		base.Start();
		
		//UpdateTargets();
	}

	protected override void Update()
	{
		base.Update();
		if(isTriggered)
			UpdateTargets();
	}

	protected override void UpdateTargets()
	{
		Vector3 target = lookTargetPosition;
		for( int i = 0; i < _enemies.Count; i++ )
		{
			target += _enemies[i].transform.position;
		}
		lookTargetPosition = target / ( (float)_enemies.Count + 1f);
		targetPosition = lookTargetPosition + Vector3.Normalize( Player.instance.position - lookTargetPosition ) * 25f;
	}

	public void Kill(GameObject go)
	{
		_enemies.Remove( go );
		Destroy(go);
		if( _enemies.Count == 0 )
			EventManager.instance.GotoNextEvent();
	}

	public override void Trigger()
	{
		if( !isTriggered )
		{
			base.Trigger();
			if( isTriggered )
			{
				float extentsUsage = 0.5f;
				Vector3 spawn = Vector3.zero;
				for( int i = 0; i < Enemies.Length; i++ )
				{
					spawn = Enemies[i].spawnPosition;
					spawn.x *= _myBounds.extents.x * ( Random.value < 0.5f ? -extentsUsage : extentsUsage );
					spawn.z *= _myBounds.extents.z * ( Random.value < 0.5f ? -extentsUsage : extentsUsage );
					_enemies.Add(Instantiate(Enemies[i].Enemy, _transform.position + spawn, Quaternion.identity) as GameObject);
					_enemies[i].transform.parent = _transform;
					Debug.Log("Making new dudes.  Bounds: " + bounds);
					_enemies[i].GetComponent<Enemy>().Here(this, Camera.main.transform);
				}
				UpdateTargets();
				orbitSpeed *= Random.value < 0.5f ? -1f : 1f;
			}
		}
	}
}

[System.Serializable]
public class EnemyTrigger
{
	public GameObject Enemy;
	public Vector3 spawnPosition;
}
