using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : Monster
{
	public List<GameObject> segments;

	public GameObject objSeg;

	private float rad = 9f;

	private float angle;

	private float a;

	private float t;

	public SpriteRenderer s;

	public override void InitStats()
	{
		base.InitStats();
		angle = Mathf.Atan2(base.pos.y - base.player.pos.y, base.pos.x - base.player.pos.x);
		rad = Vector3.Distance(base.pos, base.player.pos);
	}

	public override void InitPosition(float presetAngle = -1f)
	{
		float num = 45f + Utils.RandSign(20f);
		num += Utils.RandElem(new List<float> { 0f, 90f, 180f, 270f });
		num *= MathF.PI / 180f;
		base.InitPosition(num);
		s.flipX = base.pos.x < base.player.pos.x;
		if (base.pos.y < base.player.pos.y)
		{
			if (base.pos.x < base.player.pos.x)
			{
				s.transform.localEulerAngles = new Vector3(0f, 0f, 90f);
			}
			else
			{
				s.transform.localEulerAngles = new Vector3(0f, 0f, -90f);
			}
		}
		else
		{
			s.transform.localEulerAngles = Vector3.zero;
		}
	}

	public override IEnumerator Movement()
	{
		if (knockbacking)
		{
			rad = Vector3.Distance(base.pos, base.player.pos);
			yield break;
		}
		float num = base.speed / 16f;
		rad -= num;
		base.transform.position = rad * new Vector3(Mathf.Cos(a), Mathf.Sin(a)) + base.player.pos;
		a = angle + 0.3f * Mathf.Sin(t);
		t += 0.1f;
		if (!(Vector3.Distance(base.pos, base.player.pos) <= attackDistance))
		{
			yield return Wait(2);
		}
	}

	private IEnumerator segmentMovement()
	{
		List<Vector3> pos = new List<Vector3>();
		while (pos.Count < 100)
		{
			pos.Add(base.transform.position);
		}
		while (true)
		{
			pos.Insert(0, base.transform.position);
			if (pos.Count == 101)
			{
				pos.RemoveAt(100);
			}
			int num = 10;
			int num2 = num;
			foreach (GameObject segment in segments)
			{
				segment.transform.position = pos[num2];
				num2 += num;
			}
			yield return Wait(1);
		}
	}

	private IEnumerator segmentMovement_2()
	{
		List<Vector3> pos = new List<Vector3>();
		while (pos.Count < 100)
		{
			pos.Add(base.transform.position);
		}
		while (true)
		{
			pos.Insert(0, base.transform.position);
			if (pos.Count == 101)
			{
				pos.RemoveAt(100);
			}
			for (int i = 0; i < segments.Count; i++)
			{
				Vector3 vector;
				Vector3 position;
				if (i == 0)
				{
					vector = pos[10];
					position = segments[i + 1].transform.position;
				}
				else if (i == segments.Count - 1)
				{
					vector = segments[i - 2].transform.position;
					position = segments[i - 1].transform.position;
				}
				else
				{
					vector = segments[i - 1].transform.position;
					position = segments[i + 1].transform.position;
				}
				if (i == segments.Count - 1)
				{
					segments[i].transform.position = (position - vector).normalized * 0.25f + position;
				}
				else
				{
					segments[i].transform.position = Vector3.Lerp(vector, position, 0.5f);
				}
			}
			yield return Wait(1);
		}
	}

	private IEnumerator segmentMovement_3()
	{
		_ = (base.player.transform.position - base.transform.position).normalized;
		List<Vector3> pos = new List<Vector3>();
		for (int i = 0; i < segments.Count; i++)
		{
			float num = 0.5f * (float)i * MathF.PI / 8f;
			float y = Mathf.Sin(num);
			pos.Add(new Vector3(num, y));
		}
		int t = 0;
		while (true)
		{
			for (int j = 0; j < segments.Count; j++)
			{
				segments[j].transform.localPosition = pos[j];
			}
			pos.Clear();
			for (int k = 0; k < segments.Count; k++)
			{
				float num2 = (float)(k + t++ % 8) * MathF.PI / 8f;
				float y2 = 0.5f * Mathf.Sin(num2);
				pos.Add(new Vector3(num2, y2));
			}
			yield return Wait(10);
		}
	}
}
