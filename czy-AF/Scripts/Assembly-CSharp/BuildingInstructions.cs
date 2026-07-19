using System.Collections.Generic;
using System.IO;
using Kengine;
using UnityEngine;
using UnityEngine.UI;

public class BuildingInstructions : MonoBehaviour
{
	[Header("Settings")]
	public GameObject buildInstruction;

	public float speed = 1f;

	public float rotatePreview = 60f;

	public float cameraPositionMargin = 1f;

	public bool rotateModel = true;

	public bool rotateBlock = true;

	[Header("Components")]
	public Transform rig;

	public Transform lineRenderer;

	public GameObject partIcon;

	public Text part;

	private GameObject build;

	private int index;

	private Quaternion cameraRotation;

	private Vector3 cameraStartRotation;

	private Vector3 cameraStartPosition;

	private Vector3 cameraPosition;

	private Transform currentBlock;

	private List<Transform> blocks = new List<Transform>();

	private void Awake()
	{
		Audio.PrepareAudio(GetComponent<AudioSource>(), "Audio");
		cameraStartPosition = rig.position;
		cameraStartRotation = rig.eulerAngles;
		cameraPosition = cameraStartPosition;
		part.text = "";
		partIcon.SetActive(value: false);
		build = Object.Instantiate(buildInstruction, Vector3.zero, Quaternion.identity);
		foreach (Transform item in build.transform)
		{
			blocks.Add(item);
		}
		blocks.Sort(SortByY);
		Description();
		Show();
	}

	private void Update()
	{
		if (currentBlock != null)
		{
			Vector3 center = currentBlock.GetComponent<Renderer>().bounds.center;
			Camera.main.WorldToScreenPoint(center);
			if (center.y > cameraPositionMargin)
			{
				cameraPosition.y = cameraStartPosition.y + 0.25f;
			}
			else
			{
				cameraPosition = cameraStartPosition;
			}
		}
		rig.position = Vector3.Lerp(rig.position, cameraPosition, Time.deltaTime * 10f);
	}

	private void Show()
	{
		iTween.RotateTo(build, iTween.Hash("rotation", new Vector3(0f, 0f - rotatePreview, 0f), "delay", 0.25f, "time", 4f, "easetype", "easeInOutSine"));
		Invoke("Hide", 4.5f);
	}

	private void Hide()
	{
		foreach (Transform block in blocks)
		{
			block.gameObject.SetActive(value: false);
		}
		build.transform.eulerAngles = Vector3.zero;
		Invoke("Build", 0.5f);
	}

	private void Build()
	{
		if (index - 1 >= 0)
		{
			blocks[index - 1].gameObject.layer = 1;
		}
		currentBlock = blocks[index];
		partIcon.SetActive(value: true);
		string text = blocks[index].name.Replace("%", "");
		part.text = text;
		Audio.Play("Audio/block");
		GameObject obj = Object.Instantiate(lineRenderer.gameObject, Vector3.zero, Quaternion.identity);
		Vector3[] array = new Vector3[2];
		Vector3 center = blocks[index].GetComponent<Renderer>().bounds.center;
		array[0] = center + blocks[index].up;
		array[1] = center;
		obj.GetComponent<LineRenderer>().SetPositions(array);
		Object.Destroy(obj, 0.75f * speed);
		blocks[index].gameObject.SetActive(value: true);
		blocks[index].gameObject.layer = 12;
		cameraRotation = blocks[index].rotation * Quaternion.Euler(cameraStartRotation);
		cameraRotation = Quaternion.Euler(cameraStartRotation.x, cameraRotation.eulerAngles.y, 0f);
		if (index > 0 && rotateModel && blocks[index].name != "%")
		{
			iTween.RotateTo(rig.gameObject, iTween.Hash("rotation", cameraRotation.eulerAngles, "time", 1f * speed, "easetype", "easeInOutQuint"));
		}
		iTween.ScaleFrom(blocks[index].gameObject, iTween.Hash("scale", blocks[index].localScale / 2f, "time", 0.1f * speed, "easetype", "easeOutBack"));
		iTween.MoveTo(blocks[index].gameObject, iTween.Hash("position", blocks[index].position, "delay", 0.75f * speed, "time", 0.15f * speed, "easetype", "easeOutSine"));
		blocks[index].position = blocks[index].position + blocks[index].up;
		Invoke("PlaySound", 0.75f * speed);
		if (blocks[index].eulerAngles != Vector3.zero && rotateBlock)
		{
			Vector3 eulerAngles = blocks[index].eulerAngles;
			blocks[index].eulerAngles = Vector3.zero;
			iTween.RotateTo(blocks[index].gameObject, iTween.Hash("rotation", eulerAngles, "delay", 0.1f * speed, "time", 0.5f * speed, "easetype", "easeOutQuart"));
		}
		index++;
		if (index < blocks.Count)
		{
			Invoke("Build", 1.5f * speed);
		}
		else
		{
			Invoke("Complete", 1.5f * speed);
		}
	}

	private void Complete()
	{
		currentBlock = null;
		cameraPosition = cameraStartPosition;
		iTween.RotateTo(rig.gameObject, iTween.Hash("rotation", cameraStartRotation, "time", 1f, "easetype", "easeInOutQuint"));
		blocks[index - 1].gameObject.layer = 1;
		partIcon.SetActive(value: false);
		part.text = "";
		Invoke("CompleteShow", 1f);
	}

	private void CompleteShow()
	{
		iTween.RotateTo(build, iTween.Hash("rotation", new Vector3(0f, 0f - rotatePreview, 0f), "delay", 0.25f, "time", 4f, "easetype", "easeInOutSine"));
		Invoke("CompleteEnd", 5f);
	}

	private void CompleteEnd()
	{
	}

	private void Description()
	{
		string text = $"Instructions for building a {buildInstruction.name} using Asset Forge ({Application.version})\n\n";
		text += "Asset Forge website: https://assetforge.io/\n\n";
		text += "This build uses the following blocks (in build order):\n";
		foreach (Transform block in blocks)
		{
			string arg = block.name.Replace("%", "");
			text += $"{arg}, ";
		}
		text = text.Substring(0, text.Length - 2);
		text += "\n\nLike to see more? Make sure to like, subscribe and leave a comment!";
		File.WriteAllText($"Recordings/{buildInstruction.name}.txt", text);
	}

	private void PlaySound()
	{
		Audio.Play("Audio/placeA, Audio/placeB", pitch: true, 0.25f);
	}

	private static int SortByY(Transform p1, Transform p2)
	{
		int num = p1.position.y.CompareTo(p2.position.y);
		if (num != 0)
		{
			return num;
		}
		int num2 = p1.name.CompareTo(p2.name);
		if (num2 != 0)
		{
			return num2;
		}
		return p2.position.z.CompareTo(p1.position.z);
	}
}
