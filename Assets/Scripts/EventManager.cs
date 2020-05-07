using UnityEngine;
using UnityEditor;
using System.Collections;

[UnityEngine.ExecuteInEditMode]
public class EventManager : MonoBehaviour
{

	public static EventManager instance;

	public GameObject[] Events;

	private GameEvent _targetEvent;
	private GameEvent _nextEvent;

	private Vector3[] eventPositions;

	private int _eventIndex = -1;

	void Awake()
	{
		if( instance == null )
			instance = this;
	}

	void Start()
	{

		if( Events == null )
			Debug.LogError("There need to be Events specified via Inspector");

		//targetEvent = Events[_eventIndex].GetComponent<GameEvent>();
		GotoNextEvent();

		eventPositions = new Vector3[Events.Length];

		for( int i = 0; i < Events.Length; i++ )
		{
			eventPositions[i] = Events[i].transform.position;
		}

	}

	void Update()
	{
		if( eventPositions == null || eventPositions.Length != Events.Length )
			eventPositions = new Vector3[Events.Length];

		for( int i = 1; i < Events.Length; i++ )
		{
			eventPositions[i] = Events[i].transform.position;
			Debug.DrawLine(eventPositions[i - 1], eventPositions[i]);
		}
	}

	public void GotoNextEvent()
	{
		//Debug.Log("Triggered! " + this.GetType());
		_eventIndex++;
		if( _eventIndex >= Events.Length )
		{
			foreach( var i in Events )
				i.SendMessage("Reset");
			_eventIndex = 0;
		}
		targetEvent = Events[_eventIndex].GetComponent<GameEvent>();
		if( _eventIndex + 1 >= Events.Length )
			nextEvent = Events[0].GetComponent<GameEvent>();
		else
			nextEvent = Events[_eventIndex + 1].GetComponent<GameEvent>();

		Player.instance.TargetChanged();
	}

	public GameEvent nextEvent
	{
		get { return _nextEvent; }
		protected set { _nextEvent = value; }
	}

	public GameEvent targetEvent
	{
		get
		{
			return _targetEvent;
		}
		set
		{
			Debug.Log("TargetEvent Updated." + value);
			_targetEvent = value;
			MyDebug.DrawCircle(_targetEvent.targetPosition, 10f, Color.white, 10f);
		}
	}
}
