using DG.Tweening;
using UnityEngine;

public class IceCreamSpoonGraphics : MonoBehaviour
{
	private static readonly int IsPlayingHash;

	[SerializeField]
	private IceCreamScoopAnimation m_ScoopAnimation;

	public float ScoopValue;

	public float PullValue;

	public float TransformValue;

	private Vector3 m_LocalRestPoint;

	private Quaternion m_LocalRestRotation;

	[SerializeField]
	private Vector3 m_LocalPullAngles;

	[SerializeField]
	private bool m_IsPlaying;

	private Tween m_Tween;

	[Header("Carve Options")]
	[SerializeField]
	private float m_CarveStartDelay;

	[SerializeField]
	private Vector2 m_CarveEndUVA;

	[SerializeField]
	private Vector2 m_CarveStartUVA;

	[SerializeField]
	private Vector2 m_CarveEndUVB;

	[SerializeField]
	private Vector2 m_CarveStartUVB;

	[SerializeField]
	private float m_CarveDuration;

	public Vector3 ScoopPosition => default(Vector3);

	public Quaternion ScoopRotation => default(Quaternion);

	public Vector3 TargetPoint { get; set; }

	public Vector3 PullPoint { get; set; }

	public bool IsPlaying
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public void ResetTween()
	{
	}

	public void StartTween(IceCreamFlavourGraphics graphics)
	{
	}

	private void ApplyCarveBlit(IceCreamFlavourGraphics graphics, float t)
	{
	}

	public void PlayPullback()
	{
	}

	private Tween CreatePullBack()
	{
		return null;
	}

	public void SetScoopMaterial(Material material)
	{
	}

	private void Awake()
	{
	}

	private void UpdateScoopValue()
	{
	}
}
