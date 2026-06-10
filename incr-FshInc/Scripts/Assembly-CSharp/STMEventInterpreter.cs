using System.Collections.Generic;
using UnityEngine;

public class STMEventInterpreter : MonoBehaviour
{
	private SuperTextMesh _stm;

	public GameObject confetti;

	public AudioSource au;

	public AudioClip myClip;

	public STMSampleLink link;

	private List<STMSampleLink> allLinks = new List<STMSampleLink>();

	private List<SpriteRenderer> allBGs = new List<SpriteRenderer>();

	public SpriteRenderer bgPrefab;

	public SuperTextMesh stm
	{
		get
		{
			if (_stm == null)
			{
				_stm = base.transform.GetComponent<SuperTextMesh>();
			}
			return _stm;
		}
	}

	public void SayMessage()
	{
		Debug.Log("Saying message!");
	}

	public void DoEvent(string s, STMTextInfo info)
	{
		Vector3 position = info.Middle + base.transform.position;
		Vector3 vector = info.BottomLeftVert + base.transform.position;
		if (s.Contains("printpos"))
		{
			Debug.Log(info.rawIndex + " " + info.readTime + " " + s);
			Debug.DrawLine(vector, vector + Vector3.down, Color.red, 10f, depthTest: false);
		}
		else if (!(s == "transcribe"))
		{
			if (s == "link")
			{
				Vector3 position2 = info.pos + base.transform.position + new Vector3((info.TopRightVert.x - info.pos.x) / 2f, info.size.y / 2f, 0f);
				STMSampleLink sTMSampleLink = Object.Instantiate(link, position2, link.transform.rotation);
				sTMSampleLink.linkName = "Custom Link Address!";
				sTMSampleLink.transform.localScale = new Vector3(info.size.x, info.size.y, 0.5f);
				allLinks.Add(sTMSampleLink);
			}
			else if (s.Length >= 2 && s.Substring(0, 2) == "bg")
			{
				Vector3 position3 = info.pos + base.transform.position + new Vector3((info.TopRightVert.x - info.pos.x) / 2f, info.size.y / 2f, 0.2f);
				SpriteRenderer spriteRenderer = Object.Instantiate(bgPrefab, position3, bgPrefab.transform.rotation);
				spriteRenderer.color = Color.red;
				spriteRenderer.transform.localScale = new Vector3(info.size.x, info.size.y, 0.5f);
				allBGs.Add(spriteRenderer);
			}
			else if (s == "confetti")
			{
				Object.Instantiate(confetti, position, confetti.transform.rotation);
			}
			else if (s == "playSound")
			{
				Debug.Log("Playing sound!");
				au.PlayOneShot(myClip, 1f);
			}
			else
			{
				Debug.Log("Unknown event: '" + s + "'");
			}
		}
	}

	public void ClearLinks()
	{
		for (int i = 0; i < allLinks.Count; i++)
		{
			Object.Destroy(allLinks[i].gameObject);
		}
		allLinks.Clear();
	}

	public void ClearBGs()
	{
		for (int i = 0; i < allBGs.Count; i++)
		{
			Object.Destroy(allBGs[i].gameObject);
		}
		allBGs.Clear();
	}
}
