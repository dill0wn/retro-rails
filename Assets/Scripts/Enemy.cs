using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{

	private EnemyEvent _parent;
	private Transform _transform;
	private Transform _target;

	private Vector3 _moveTarget;

	public float moveSpeed = 2f;
	public float nextTarget = 6f;
	public float nextDeviance = 2f;
	private float _timeToTarget = 0f;

	protected virtual void Awake()
	{
		_transform = transform;

		_moveTarget = _transform.position;

		_timeToTarget = Random.value * nextTarget;
		Random.seed = Random.Range( 0, int.MaxValue );
	}

	protected virtual void Update()
	{
		if( _target != null )
		{
			Vector3 pos = _target.position;
			pos.y = _transform.position.y;
			_transform.LookAt( _target.position );
			_transform.rotation = Quaternion.LookRotation( _target.position - _transform.position );
		}

		_timeToTarget += Time.deltaTime;
		if( _timeToTarget >= nextTarget )
			FindNewTarget();

		_transform.position = Vector3.MoveTowards( _transform.position, _moveTarget, moveSpeed * Time.deltaTime );
	}

	private void FindNewTarget()
	{
		float w = _parent.bounds.extents.x *0.25f * ( Random.value * 2f - 1f );
		float h = _parent.bounds.extents.z * 0.25f * ( Random.value * 2f - 1f );
		_moveTarget = _transform.position + new Vector3( w, 0f, h );
		_timeToTarget = Random.value * nextDeviance;
	}

	public virtual void Here( EnemyEvent boss, Transform playa )
	{
		_parent = boss;
		_target = playa;
	}

	public void Shot()
	{
		_parent.Kill( gameObject );
	}
}
