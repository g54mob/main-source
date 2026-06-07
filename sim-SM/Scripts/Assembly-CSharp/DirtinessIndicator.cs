using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

public class DirtinessIndicator : MonoBehaviourPun
{
	[SerializeField]
	private Color m_CleanColor;

	[SerializeField]
	private Color m_DirtyColor;

	[SerializeField]
	private Image m_FillImage;

	[SerializeField]
	private float m_SmoothTime;

	[SerializeField]
	private Animator m_Arrow;

	private void Start()
	{
	}

	private void OnDestroy()
	{
	}

	private void Setup()
	{
	}

	public void ArrowAnimate(bool _)
	{
	}

	[PunRPC]
	public void ArrowAnimate_RPC()
	{
	}

	[PunRPC]
	public void CleaningRateChange_RPC(float percentage)
	{
	}
}
