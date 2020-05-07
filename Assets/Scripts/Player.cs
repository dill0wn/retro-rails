using UnityEngine;
using System.Collections;

[UnityEngine.ExecuteInEditMode]
public class Player : MonoBehaviour
{
	public static Player instance;
	private Transform _transform;

	public float lerpSpeed = 0.5f;
	public float lookatSpeed = 1f;
	private Vector3 _lastPostion;
	private Vector3 _midPoint;

	void Awake()
	{
		instance = this;
		_transform = transform;

		TargetChanged();
	}

	//void Start() { }

	void Update()
	{
		GameEvent currTarget = EventManager.instance.targetEvent;
		Vector3 dest = currTarget.targetPosition;
		Vector3 look = currTarget.lookTargetPosition;

		_midPoint = (dest + _lastPostion )/ 2f;

		float v = 0.85f * Vector3.Distance(_transform.position, dest) /* * Distance(_lastPostion, dest)*/ / Vector3.Distance(_lastPostion, dest);

		_transform.position = Vector3.Lerp( _transform.position, dest, v * Time.deltaTime );

		Vector3 dir = Vector3.Normalize( look - _transform.position );

		//_transform.LookAt( _transform.position + Vector3.RotateTowards( _transform.forward, dir, lookatSpeed * Time.deltaTime, lookatSpeed * Time.deltaTime ), Vector3.up );
		_transform.LookAt(_transform.position + Vector3.Slerp(_transform.forward, dir, lookatSpeed * Time.deltaTime), Vector3.up);
	}

	public void TargetChanged()
	{
		_lastPostion = _transform.position;
	}

	void OnTriggerStay( Collider collider )
	{
		if( collider.CompareTag( "event" ) )
		{
			collider.transform.GetComponent<GameEvent>().Trigger();
		}
	}

	public Vector3 position
	{
		get { return _transform.position; }
	}
}
