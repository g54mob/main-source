using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LightningEffect : MonoBehaviour
{
	public Line lineObj;

	public Line lineObjUnmasked;

	public void SetPoints(List<Vector3> OP, string color = "", bool silent = false, bool unmasked = false)
	{
		Line component = UnityEngine.Object.Instantiate(unmasked ? lineObjUnmasked : lineObj).GetComponent<Line>();
		component.noHitbox = true;
		if (color != "")
		{
			LineRenderer line = component.line;
			Color endColor = (component.line.startColor = Utils.GetColor(color));
			line.endColor = endColor;
		}
		component.transform.parent = base.transform;
		List<Vector3> list = new List<Vector3>();
		int num = 0;
		foreach (Vector3 item3 in OP)
		{
			list.Add(item3);
			num++;
			if (item3 == OP.Last())
			{
				break;
			}
			Vector3 vector = OP[num];
			float num2 = Vector3.Distance(vector, item3);
			if (!(Vector3.Distance(vector, item3) < 0.5f))
			{
				_ = (vector - item3).normalized;
				float num3 = Mathf.Atan2(0f - item3.y + vector.y, 0f - item3.x + vector.x);
				float f = num3 + MathF.PI / 180f * (float)UnityEngine.Random.Range(5, 20);
				float f2 = num3 - MathF.PI / 180f * (float)UnityEngine.Random.Range(5, 20);
				float num4 = UnityEngine.Random.Range(0.1f, 0.5f);
				float num5 = UnityEngine.Random.Range(num4 + 0.2f, 0.8f);
				Vector3 item = item3 + new Vector3(Mathf.Cos(f), Mathf.Sin(f)) * num2 * num4;
				Vector3 item2 = item3 + new Vector3(Mathf.Cos(f2), Mathf.Sin(f2)) * num2 * num5;
				list.Add(item);
				list.Add(item2);
			}
		}
		foreach (Vector3 item4 in list)
		{
			component.UpdateLine(item4);
		}
		if (!silent)
		{
			Dungeon.Instance.audioManager.PlaySound(AudioManager.Sound.Zap);
		}
		StartCoroutine(WhiteFlash(component, color));
		StartCoroutine(Fader(component));
	}

	public void SetPointsStraight(List<Vector3> OP, string color = "", float width = 0.3f)
	{
		Line component = UnityEngine.Object.Instantiate(lineObj).GetComponent<Line>();
		if (color != "")
		{
			LineRenderer line = component.line;
			Color endColor = (component.line.startColor = Color.white);
			line.endColor = endColor;
		}
		component.transform.parent = base.transform;
		LineRenderer line2 = component.line;
		float startWidth = (component.line.endWidth = width);
		line2.startWidth = startWidth;
		component.line.numCapVertices = 2;
		component.line.numCornerVertices = 2;
		component.noHitbox = true;
		List<Vector3> list = new List<Vector3>();
		foreach (Vector3 item in OP)
		{
			list.Add(item);
		}
		foreach (Vector3 item2 in list)
		{
			component.UpdateLine(item2);
		}
		StartCoroutine(Fader(component, 10));
		StartCoroutine(WhiteFlash(component, color));
	}

	public void SetPointsWave(Vector3 a, Vector3 b, string color = "", float width = 0.3f, bool unmasked = false)
	{
		Line component = UnityEngine.Object.Instantiate(unmasked ? lineObjUnmasked : lineObj).GetComponent<Line>();
		if (color != "")
		{
			LineRenderer line = component.line;
			Color endColor = (component.line.startColor = Utils.GetColor(color));
			line.endColor = endColor;
		}
		component.transform.parent = base.transform;
		LineRenderer line2 = component.line;
		float startWidth = (component.line.endWidth = width);
		line2.startWidth = startWidth;
		component.line.numCapVertices = 5;
		component.line.numCornerVertices = 5;
		component.noHitbox = true;
		int num2 = 100;
		List<Vector3> list = new List<Vector3>();
		List<Vector3> list2 = new List<Vector3>();
		float num3 = 0.25f;
		float num4 = 3f;
		float num5 = Vector3.Distance(a, b);
		float f = Mathf.Atan2(b.y - a.y, b.x - a.x);
		for (float num6 = 0f; num6 < (float)num2; num6 += 1f)
		{
			float num7 = Mathf.Lerp(0f, num5, num6 / (float)(num2 - 1));
			float y = num3 * Mathf.Sin(MathF.PI * 2f * num4 / num5 * num7);
			list.Add(new Vector3(num7, y));
		}
		int index = 0;
		foreach (Vector3 item in list)
		{
			_ = item;
			float x = list[index].x;
			float y2 = list[index++].y;
			float x2 = x * Mathf.Cos(f) - y2 * Mathf.Sin(f) + a.x;
			float y3 = x * Mathf.Sin(f) + y2 * Mathf.Cos(f) + a.y;
			list2.Add(new Vector3(x2, y3));
		}
		foreach (Vector3 item2 in list2)
		{
			component.UpdateLine(item2);
		}
		StartCoroutine(Fader(component, 10));
	}

	private IEnumerator WhiteFlash(Line line, string color)
	{
		Color OP = line.line.startColor;
		LineRenderer line2 = line.line;
		Color endColor = (line.line.startColor = Color.white);
		line2.endColor = endColor;
		yield return Dungeon.Wait(5);
		if (color != "")
		{
			OP = Utils.GetColor(color);
		}
		LineRenderer line3 = line.line;
		endColor = (line.line.startColor = OP);
		line3.endColor = endColor;
	}

	private void Awake()
	{
		Dungeon.Instance.animationManager.lineCount++;
	}

	private void OnDestroy()
	{
		Dungeon.Instance.animationManager.lineCount--;
	}

	public IEnumerator Fader(Line line, int f = 15)
	{
		float FRAMES = f;
		float w = line.line.endWidth;
		for (int i = 0; (float)i < FRAMES; i++)
		{
			line.line.endWidth += (0f - w) / FRAMES;
			line.line.startWidth += (0f - w) / FRAMES;
			yield return null;
		}
		UnityEngine.Object.Destroy(base.gameObject);
	}
}
