using System.Collections.Generic;
using UnityEngine;

public class ExitPortal : MonoBehaviour
{
	public enum Mode
	{
		ClosedInvisible = 0,
		Closed = 1,
		Open = 2
	}

	[Readonly]
	public string momentId;

	[Readonly]
	public List<ExitPortalObstruction> obstructions;

	[Readonly]
	public AudioClip openAudioClip;

	[Readonly]
	public List<Renderer> renderers;

	private GameObject openGo;

	private GameObject closedGo;

	public Mode mode
	{
		set
		{
			if (openGo == null)
			{
				openGo = base.transform.FindDescendant("open").gameObject;
				closedGo = base.transform.FindDescendant("closed").gameObject;
			}
			openGo.SetActive(value == Mode.Open);
			closedGo.SetActive(value != Mode.Open);
			foreach (ExitPortalObstruction obstruction in obstructions)
			{
				obstruction.gameObject.SetActive(value != Mode.Open);
			}
			foreach (Renderer renderer in renderers)
			{
				renderer.enabled = value != Mode.ClosedInvisible;
			}
		}
	}

	public float outsideT
	{
		get
		{
			if (!openGo.activeSelf)
			{
				return 0f;
			}
			float x = base.transform.worldToLocalMatrix.MultiplyPoint(Player.instance.eyePos).x;
			return Util.LerpScale(x, -0.1f, -2f, 0f, 1f);
		}
	}

	public void PlayOpenAudio()
	{
		AudioOneShot.Play3D(base.gameObject, openAudioClip, false, 2f, 20f);
	}
}
