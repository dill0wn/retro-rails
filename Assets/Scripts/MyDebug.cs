using UnityEngine;
using System.Linq;
using System.Collections;

public static class MyDebug {
	private static Vector3[] Square = {
		new Vector3(-0.5f, 0f, -0.5f), 
		new Vector3(0.5f, 0f, -0.5f), 
		new Vector3(0.5f, 0f, 0.5f), 
		new Vector3(-0.5f, 0f, 0.5f), 
	};

	public static void DrawLine( Vector3 pos1, Vector3 pos2, Color c, float t,Object msg = null )
	{
		MyDebug.Log( msg );
		Debug.DrawLine( pos1, pos2, c, t );
	}
	public static void DrawLine( Vector3 pos1, Vector3 pos2, Color c, Object msg = null )
	{
		MyDebug.Log( msg );
		Debug.DrawLine( pos1, pos2, c );
	}
	public static void DrawLine( Vector3 pos1, Vector3 pos2, Object msg = null )
	{
		MyDebug.Log( msg );
		Debug.DrawLine( pos1, pos2 );
	}
	public static void DrawLine( Ray ray, Color c, float t, Object msg = null )
	{
		MyDebug.Log( msg );
		Debug.DrawLine( ray.origin, ray.origin + ray.direction*100f, c, t );
	}
	public static void DrawLine( Ray ray, Color c, Object msg = null )
	{
		MyDebug.Log( msg );
		Debug.DrawLine( ray.origin, ray.origin + ray.direction*100f, c );
	}
	public static void DrawLine( Ray ray, Object msg = null )
	{
		MyDebug.Log( msg );
		Debug.DrawLine( ray.origin, ray.origin + ray.direction*100f );
	}
	public static void DrawSquare( Vector3 position, float scale, Color c, float t )
	{
		//MyDebug.Log( msg );
		Debug.DrawLine( position + Square[0] * scale, position + Square[1] * scale, c, t );
		Debug.DrawLine( position + Square[1] * scale, position + Square[2] * scale, c, t );
		Debug.DrawLine( position + Square[2] * scale, position + Square[3] * scale, c, t );
		Debug.DrawLine( position + Square[3] * scale, position + Square[0] * scale, c, t );
	}
	public static void DrawSquare( Vector3 position, float scale, Color c, Object msg = null )
	{
		MyDebug.Log( msg );
		Debug.DrawLine( position + Square[0] * scale, position + Square[1] * scale, c );
		Debug.DrawLine( position + Square[1] * scale, position + Square[2] * scale, c );
		Debug.DrawLine( position + Square[2] * scale, position + Square[3] * scale, c );
		Debug.DrawLine( position + Square[3] * scale, position + Square[0] * scale, c );
	}
	public static void DrawSquare( Vector3 position, Color c, float t, Object msg = null )
	{
		MyDebug.Log( msg );
		Debug.DrawLine( position + Square[0], position + Square[1], c, t );
		Debug.DrawLine( position + Square[1], position + Square[2], c, t );
		Debug.DrawLine( position + Square[2], position + Square[3], c, t );
		Debug.DrawLine( position + Square[3], position + Square[0], c, t );
	}
	public static void DrawSquare( Vector3 position, Color c, Object msg = null )
	{
		MyDebug.Log( msg );
		Debug.DrawLine( position + Square[0], position + Square[1], c );
		Debug.DrawLine( position + Square[1], position + Square[2], c );
		Debug.DrawLine( position + Square[2], position + Square[3], c );
		Debug.DrawLine( position + Square[3], position + Square[0], c );
	}
	public static void DrawSquare( Vector3 position, Object msg = null )
	{
		MyDebug.Log( msg );
		Debug.DrawLine( position + Square[0], position + Square[1] );
		Debug.DrawLine( position + Square[1], position + Square[2] );
		Debug.DrawLine( position + Square[2], position + Square[3] );
		Debug.DrawLine( position + Square[3], position + Square[0] );
	}
	public static void DrawCircle( Vector3 position, float radius, Color c, float t, Object msg = null )
	{
		MyDebug.Log( msg );
		int detail = 12;		
		float full_circle = 360f * Mathf.Deg2Rad;
		
		for(int i=0 ; i< detail; i ++) {
			float arc = full_circle / detail;
			MyDebug.DrawLine(position + new Vector3(radius * Mathf.Cos(arc * i ),  0, radius * Mathf.Sin(arc * i)), 
			                 position + new Vector3(radius * Mathf.Cos(arc * (i+1) ),  0, radius * Mathf.Sin(arc * (i+1))),c, t ); 
		}
	}



	public static void Log(Object msg )
	{
		if( msg != null && msg.ToString() != "" )
			Debug.Log( msg + "\n" + StackTraceUtility.ExtractStackTrace() );
	}
	public static void Log( object msg )
	{
		if( msg != null && msg.ToString() != "" )
			Debug.Log( msg + "\n" + StackTraceUtility.ExtractStackTrace() );
	}
}
