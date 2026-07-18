using UnityEngine;
using UnityEngine.Serialization;

public class ObjectRenderSnapable : MonoBehaviour
{
	public enum eSnapAngleStrategy
	{
		WorldSpaceRotation = 0,
		CameraSpaceY = 1
	}

	private Vector3 LocalPositionPreSnap;

	private Quaternion LocalRotationPreSnap;

	private Quaternion WorldRotationPreSnap;

	[Tooltip("Should position be snapped?")]
	[FormerlySerializedAs("ShouldSnapPosition")]
	public bool SnapPosition = true;

	[Tooltip("Should Euler rotation angles be snapped?")]
	[FormerlySerializedAs("shouldSnapAngles")]
	public bool SnapEulerAngles = true;

	[Tooltip("Strategy that should be used for snapping rotation angles.")]
	public eSnapAngleStrategy SnapAngleStrategy;

	[Tooltip("Resolution to which angles should be snapped")]
	public float angleResolution = 30f;

	[FormerlySerializedAs("UseRootPixelGrid")]
	[Tooltip("When true, the pixels of this object are snapped into alignment with another transform.")]
	public bool AlignPixelGrid;

	[Tooltip("The transform to align this object's pixels to when 'Align Pixel Grid' is true. If empty, the root transform is used.")]
	public Transform PixelGridReference;

	private Renderer _renderer;

	private int _pixelSize = 3;

	public Vector3 WorldPositionPreSnap { get; private set; }

	public int TransformDepth { get; private set; }

	public float OffsetBias => 0.5f;

	public Vector3 PixelGridReferencePosition { get; private set; }

	public bool ShouldSnapAngles()
	{
		return SnapEulerAngles;
	}

	public float AngleResolution()
	{
		return angleResolution;
	}

	public void SaveTransform()
	{
		LocalPositionPreSnap = base.transform.localPosition;
		WorldPositionPreSnap = base.transform.position;
		LocalRotationPreSnap = base.transform.localRotation;
		WorldRotationPreSnap = base.transform.rotation;
		if (PixelGridReference != null)
		{
			PixelGridReferencePosition = PixelGridReference.position;
		}
		else
		{
			PixelGridReferencePosition = base.transform.root.position;
		}
	}

	public void RestoreTransform()
	{
		base.transform.localPosition = LocalPositionPreSnap;
		base.transform.localRotation = LocalRotationPreSnap;
	}

	public void Start()
	{
		int num = 0;
		Transform parent = base.transform;
		while (parent.parent != null && num < 100)
		{
			num++;
			parent = parent.parent;
		}
		TransformDepth = num;
		_renderer = GetComponent<Renderer>();
		if (_renderer == null)
		{
			return;
		}
		for (int i = 0; i < _renderer.materials.Length; i++)
		{
			if (_renderer.materials[i].HasProperty("_PixelGridOrigin"))
			{
				_renderer.materials[i] = new Material(_renderer.materials[i]);
				_renderer.materials[i].EnableKeyword("USE_OBJECT_POSITION_ON");
				_renderer.materials[i].EnableKeyword("USE_OBJECT_POSITION");
				_pixelSize = Mathf.RoundToInt(_renderer.materials[i].GetFloat("_PixelSize"));
			}
		}
	}

	public int GetPixelSize()
	{
		return _pixelSize;
	}

	public void SnapAngles(Camera camera)
	{
		if (ShouldSnapAngles())
		{
			Vector3 eulerAngles = WorldRotationPreSnap.eulerAngles;
			float num = AngleResolution();
			switch (SnapAngleStrategy)
			{
			case eSnapAngleStrategy.WorldSpaceRotation:
			{
				Vector3 eulerAngles3 = new Vector3(Mathf.Round(eulerAngles.x / num) * num, Mathf.Round(eulerAngles.y / num) * num, Mathf.Round(eulerAngles.z / num) * num);
				base.transform.eulerAngles = eulerAngles3;
				break;
			}
			case eSnapAngleStrategy.CameraSpaceY:
			{
				float y = camera.transform.eulerAngles.y;
				eulerAngles.y -= y;
				Vector3 eulerAngles2 = new Vector3(Mathf.Round(eulerAngles.x / num) * num, Mathf.Round(eulerAngles.y / num) * num, Mathf.Round(eulerAngles.z / num) * num);
				eulerAngles2.y += y;
				base.transform.eulerAngles = eulerAngles2;
				break;
			}
			}
		}
	}
}
