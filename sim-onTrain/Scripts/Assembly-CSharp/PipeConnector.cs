using UnityEngine;

public class PipeConnector : MonoBehaviour
{
	public enum ConnectorDirection
	{
		Forward = 0,
		Back = 1,
		Right = 2,
		Left = 3,
		Up = 4,
		Down = 5
	}

	[Tooltip("Borunun baglanacagi nokta. Forward yonu borunun uzayacagi yone bakmali.")]
	public Transform connectionPoint;

	[Tooltip("Bu noktaya bir boru bagli mi?")]
	public bool isOccupied;

	[SerializeField]
	private bool showGizmos = true;

	[SerializeField]
	private float gizmoRadius = 0.1f;

	[Header("Direction Setup")]
	[Tooltip("Borunun hangi yone uzayacagini sec. Butona basinca uygulanir.")]
	public ConnectorDirection direction;

	public void ApplyDirection()
	{
		if (connectionPoint == null)
		{
			Debug.LogWarning("ConnectionPoint atanmamis!");
			return;
		}
		Vector3 worldDirection = GetWorldDirection();
		connectionPoint.rotation = Quaternion.LookRotation(worldDirection, Vector3.up);
	}

	public void CreateConnectionPoint()
	{
		if (connectionPoint != null)
		{
			Object.Destroy(connectionPoint.gameObject);
		}
		GameObject gameObject = new GameObject("PipeConnectionPoint");
		gameObject.transform.parent = base.transform;
		gameObject.transform.localPosition = Vector3.zero;
		connectionPoint = gameObject.transform;
		ApplyDirection();
	}

	private Vector3 GetWorldDirection()
	{
		return direction switch
		{
			ConnectorDirection.Forward => base.transform.forward, 
			ConnectorDirection.Back => -base.transform.forward, 
			ConnectorDirection.Right => base.transform.right, 
			ConnectorDirection.Left => -base.transform.right, 
			ConnectorDirection.Up => base.transform.up, 
			ConnectorDirection.Down => -base.transform.up, 
			_ => base.transform.forward, 
		};
	}

	private void OnDrawGizmos()
	{
		if (showGizmos && !(connectionPoint == null))
		{
			Gizmos.color = (isOccupied ? Color.red : Color.cyan);
			Gizmos.DrawWireSphere(connectionPoint.position, gizmoRadius);
			Vector3 position = connectionPoint.position;
			Vector3 vector = position + connectionPoint.forward * 0.3f;
			Gizmos.color = Color.blue;
			Gizmos.DrawLine(position, vector);
			Vector3 vector2 = connectionPoint.right * 0.05f;
			Vector3 vector3 = connectionPoint.up * 0.05f;
			Gizmos.DrawLine(vector, vector - connectionPoint.forward * 0.06f + vector2);
			Gizmos.DrawLine(vector, vector - connectionPoint.forward * 0.06f - vector2);
			Gizmos.DrawLine(vector, vector - connectionPoint.forward * 0.06f + vector3);
			Gizmos.DrawLine(vector, vector - connectionPoint.forward * 0.06f - vector3);
		}
	}
}
