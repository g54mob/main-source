using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Wwise/AkAmbient")]
public class AkAmbient : AkEvent
{
	public static Dictionary<uint, AkMultiPosEvent> multiPosEventTree;

	public AkMultiPositionType MultiPositionType;

	public MultiPositionTypeLabel multiPositionTypeLabel;

	private static Color SPHERE_DEFAULT_COLOR;

	public Color attenuationSphereColor;

	public AkAmbientLargeModePositioner[] LargeModePositions;

	[HideInInspector]
	[SerializeField]
	public List<Vector3> multiPositionArray;

	public override void OnEnable()
	{
	}

	protected override void Start()
	{
	}

	private void OnDisable()
	{
	}

	protected new void OnDestroy()
	{
	}

	public override void HandleEvent(GameObject in_gameObject)
	{
	}

	public void OnDrawGizmosSelected()
	{
	}

	public AkPositionArray BuildMultiDirectionArray(AkMultiPosEvent eventPosList)
	{
		return null;
	}

	private AkPositionArray BuildAkPositionArray()
	{
		return null;
	}
}
