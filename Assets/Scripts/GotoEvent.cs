using UnityEngine;
using System.Collections;

public class GotoEvent : GameEvent {

	public float gotoRate = 0.8f;
	public float gotoTurn = 0.75f;

	protected override void Awake()
	{
		base.Awake();
	}

	protected override void Start () {
		base.Start();
		//this.targetPosition = transform.position;
	}

	protected override void Update()
	{
		base.Update();
		//base.UpdateTargets();
		lookTargetPosition = EventManager.instance.nextEvent.targetPosition;
	}

	public override void Trigger()
	{
		if( !isTriggered )
		{
			base.Trigger();
			if( isTriggered )
			{
				EventManager.instance.GotoNextEvent();
			}
		}
	}
}