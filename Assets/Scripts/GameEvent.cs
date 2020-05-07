using UnityEngine;
using System;
using System.Runtime;
using System.Collections;

public abstract class GameEvent : MonoBehaviour
{
	protected Transform _transform;
	protected Vector3 _targetPosition;
	protected Vector3 _lookTargetPosition;

	protected Collider _collider;
	protected Bounds _myBounds;

	protected bool _isTriggered = false;

	protected virtual void Awake()
	{
		_transform = transform;
		_collider = GetComponent<Collider>();
		if( _collider == null )
			_collider = gameObject.AddComponent<BoxCollider>();

		bounds = new Bounds(_transform.position, Vector3.Scale(_collider.bounds.extents, _transform.localScale));

		Destroy(_transform.FindChild("marker").gameObject);
	}

	protected virtual void Start()
	{
		targetPosition = _transform.position;
		lookTargetPosition = _transform.position;
	}

	protected virtual void Update()
	{
		//this.UpdateTargets();
	}

	protected virtual void UpdateTargets()
	{
		targetPosition = _transform.position;
		lookTargetPosition = _transform.position;
	}

	public virtual void Trigger()
	{
		if( EventManager.instance.targetEvent == this )
		{
			if( !isTriggered )
			{
				Debug.Log(this.GetType() + ": Triggered!");
				isTriggered = true;
			}
		}
		else
		{
			Debug.Log("Thing has been Triggered, but not in order");
		}
	}

	public void Reset()
	{
		if( isTriggered )
		{
			isTriggered = false;
			this.Start();
		}
		else
			throw new System.NotSupportedException();
	}

	public void Draw() { }

	public override string ToString()
	{
		return this.GetType() + ", target:(" + targetPosition + "), look:(" + lookTargetPosition + ")";
	}

	public bool isTriggered
	{
		get { return _isTriggered; }
		protected set { _isTriggered = value; }
	}

	public Bounds bounds
	{
		get { return _myBounds; }
		protected set { _myBounds = value; }
	}

	public Vector3 targetPosition
	{
		get { return _targetPosition; }
		protected set
		{
			MyDebug.DrawSquare(value, 25f, Color.yellow, 10f);
			_targetPosition = value;
		}
	}

	public Vector3 lookTargetPosition
	{
		get { return _lookTargetPosition; }
		protected set
		{
			MyDebug.DrawSquare(value, 25f, Color.cyan, 10f);
			_lookTargetPosition = value;
		}
	}
}
