using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vectrosity;

[AddComponentMenu("Vectrosity/LineManager")]
public class LineManager : MonoBehaviour
{
	private static List<VectorLine> lines;

	private static List<Transform> transforms;

	private static int lineCount = 0;

	private bool destroyed = false;

	private void Awake()
	{
		lines = new List<VectorLine>();
		transforms = new List<Transform>();
		Object.DontDestroyOnLoad(this);
	}

	public void AddLine(VectorLine vectorLine, Transform thisTransform, float time)
	{
		if (time > 0f)
		{
			StartCoroutine(DisableLine(vectorLine, time, true));
		}
		for (int i = 0; i < lineCount; i++)
		{
			if (vectorLine == lines[i])
			{
				return;
			}
		}
		lines.Add(vectorLine);
		transforms.Add(thisTransform);
		if (++lineCount == 1)
		{
			base.enabled = true;
		}
	}

	public void DisableLine(VectorLine vectorLine, float time)
	{
		StartCoroutine(DisableLine(vectorLine, time, false));
	}

	private IEnumerator DisableLine(VectorLine vectorLine, float time, bool remove)
	{
		yield return new WaitForSeconds(time);
		if (remove)
		{
			RemoveLine(vectorLine);
		}
		else
		{
			VectorLine.Destroy(ref vectorLine);
		}
		vectorLine = null;
	}

	private void LateUpdate()
	{
		if (!VectorLine.camTransformExists)
		{
			return;
		}
		for (int i = 0; i < lineCount; i++)
		{
			if (lines[i].vectorObject != null)
			{
				lines[i].Draw3D(transforms[i]);
			}
			else
			{
				RemoveLine(i--);
			}
		}
		if (VectorLine.CameraHasMoved())
		{
			VectorManager.DrawArrayLines();
		}
		VectorLine.UpdateCameraInfo();
		VectorManager.DrawArrayLines2();
	}

	private void RemoveLine(int i)
	{
		lines.RemoveAt(i);
		transforms.RemoveAt(i);
		lineCount--;
		DisableIfUnused();
	}

	public void RemoveLine(VectorLine vectorLine)
	{
		for (int i = 0; i < lineCount; i++)
		{
			if (vectorLine == lines[i])
			{
				RemoveLine(i);
				VectorLine.Destroy(ref vectorLine);
				break;
			}
		}
	}

	public void DisableIfUnused()
	{
		if (!destroyed && lineCount == 0 && VectorManager.arrayCount == 0 && VectorManager.arrayCount2 == 0)
		{
			base.enabled = false;
		}
	}

	public void EnableIfUsed()
	{
		if (VectorManager.arrayCount == 1 || VectorManager.arrayCount2 == 1)
		{
			base.enabled = true;
		}
	}

	public void StartCheckDistance()
	{
		InvokeRepeating("CheckDistance", 0.01f, VectorManager.distanceCheckFrequency);
	}

	private void CheckDistance()
	{
		VectorManager.CheckDistance();
	}

	private void OnDestroy()
	{
		destroyed = true;
	}
}
