using UnityEngine;

[AddComponentMenu("Wwise/AkEnvironmentPortal")]
[RequireComponent(typeof(BoxCollider))]
public class AkEnvironmentPortal : MonoBehaviour
{
	public const int MAX_ENVIRONMENTS_PER_PORTAL = 2;

	public Vector3 axis;

	public AkEnvironment[] environments;

	private BoxCollider m_BoxCollider;

	private BoxCollider BoxCollider => null;

	public bool EnvironmentsShareAuxBus => false;

	public float GetAuxSendValueForPosition(Vector3 in_position, int index)
	{
		return 0f;
	}
}
