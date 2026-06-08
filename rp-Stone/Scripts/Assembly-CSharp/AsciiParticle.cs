using System;
using System.Collections.Generic;
using UnityEngine;

public class AsciiParticle : MonoBehaviour
{
	public Vector3 velocity;

	public Vector3 acceleration;

	public Vector3 drag = Vector3.one;

	public float groundY = 26f;

	public bool groundRelativeToStartY;

	public float bounce = 1f;

	public Color[] colorProgression;

	public int lifetime = 30;

	public float lineDrawThreshold = 1f;

	public bool combineOverlaps = true;

	public float cameraMoveScale = 1f;

	private int _elapsedTics;

	protected DateTime timestamp;

	private bool firstUpdate = true;

	private float startY;

	protected AsciiParticle prefab;

	private static Dictionary<AsciiParticle, List<AsciiParticle>> particlePool = new Dictionary<AsciiParticle, List<AsciiParticle>>();

	public bool isDead => _elapsedTics >= lifetime;

	public int elapsedTics => _elapsedTics;

	public event Action<AsciiParticle> OnReset;

	public virtual void Reset()
	{
		base.transform.position = prefab.transform.position;
		velocity = prefab.velocity;
		acceleration = prefab.acceleration;
		drag = prefab.drag;
		groundY = prefab.groundY;
		bounce = prefab.bounce;
		for (int i = 0; i < colorProgression.Length; i++)
		{
			colorProgression[i] = prefab.colorProgression[i];
		}
		lifetime = prefab.lifetime;
		lineDrawThreshold = prefab.lineDrawThreshold;
		_elapsedTics = 0;
		timestamp = DateTime.Now;
		firstUpdate = true;
		if (this.OnReset != null)
		{
			this.OnReset(this);
		}
	}

	public virtual void UpdateTic()
	{
		if (!isDead)
		{
			_elapsedTics++;
			Vector3 position = base.transform.position;
			if (firstUpdate)
			{
				firstUpdate = false;
				startY = position.y;
			}
			position += velocity;
			float num = (groundRelativeToStartY ? (startY + groundY) : groundY);
			if (position.y > num)
			{
				position.y = num;
				velocity.y = 0f - velocity.y;
				velocity *= Mathf.Clamp01(bounce);
			}
			velocity.x *= drag.x;
			velocity.y *= drag.y;
			base.transform.position = position;
			velocity += acceleration;
		}
	}

	public virtual Color ComputeColor(AsciiRenderProcedural r)
	{
		if (colorProgression.Length == 0)
		{
			return r.defaultForegroundColor;
		}
		if (colorProgression.Length == 1 || lifetime <= 1)
		{
			return colorProgression[0];
		}
		float value = (float)_elapsedTics / (float)(lifetime - 1);
		value = Mathf.Clamp01(value);
		value *= (float)(colorProgression.Length - 1);
		int num = Mathf.FloorToInt(value);
		int num2 = Mathf.Min(num + 1, colorProgression.Length - 1);
		return Color.Lerp(colorProgression[num], colorProgression[num2], value - (float)num);
	}

	public virtual void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		if (isDead)
		{
			return;
		}
		Vector3 position = base.transform.position;
		int x = Mathf.RoundToInt(position.x);
		int num = Mathf.RoundToInt(position.y * 2f);
		AsciiCellProcedural cell = r.GetCell(x, num >> 1);
		if (cell == null)
		{
			return;
		}
		int value = cell.GetValue();
		int asciiValue;
		if (velocity.magnitude >= lineDrawThreshold)
		{
			float num2 = Mathf.Atan2(velocity.y, velocity.x);
			float num3 = MathF.PI / 8f;
			float num4 = num3 * 3f;
			float num5 = num3 * 5f;
			float num6 = MathF.PI - num3;
			if ((num2 < num3 && num2 > 0f - num3) || num2 > num6 || num2 < 0f - num6)
			{
				float num7 = Mathf.Repeat(position.y * 2f, 1f);
				asciiValue = ((num7 > 0.5f && num % 2 == 0) ? SpecialSymbols.Map('\u00af') : ((!(num7 < 0.5f) || num % 2 != 1) ? 45 : 95));
			}
			else
			{
				asciiValue = (((!(num2 >= num3) || !(num2 <= num4)) && (!(num2 >= 0f - num6) || !(num2 <= 0f - num5))) ? (((!(num2 > num4) || !(num2 < num5)) && (!(num2 < 0f - num4) || !(num2 > 0f - num5))) ? 47 : ((combineOverlaps && (value == 46 || value == 44)) ? 33 : ((!combineOverlaps || value != 39) ? 124 : SpecialSymbols.Map('¡')))) : 92);
			}
		}
		else
		{
			float num8 = Mathf.Repeat(position.x, 1f);
			float num9 = Mathf.Atan2(velocity.y, velocity.x);
			if (num % 2 == 0)
			{
				asciiValue = ((combineOverlaps && value == 46) ? 58 : ((combineOverlaps && value == 44) ? 59 : ((!(num8 > 0.5f) || (!(num9 < -2.1991148f) && (!(num9 > 0f) || !(num9 < 0.9424779f)))) ? 39 : 96)));
			}
			else
			{
				bool flag = combineOverlaps && (value == 96 || value == 39);
				asciiValue = ((num8 > 0.5f && (num9 > 2.1991148f || (num9 < 0f && num9 > -0.9424779f))) ? ((!flag) ? 44 : 59) : ((!flag) ? 46 : 58));
			}
		}
		Color foreground = ComputeColor(r);
		cell.SetValue(asciiValue, foreground);
	}

	protected virtual void Awake()
	{
	}

	public static AsciiParticle InstantiateFromPrefab(AsciiParticle prefab)
	{
		AsciiParticle asciiParticle = null;
		if (particlePool.ContainsKey(prefab))
		{
			List<AsciiParticle> list = particlePool[prefab];
			if (list.Count > 0)
			{
				asciiParticle = list[0];
				list.RemoveAt(0);
			}
		}
		if (asciiParticle == null)
		{
			asciiParticle = UnityEngine.Object.Instantiate(prefab);
			asciiParticle.prefab = prefab;
		}
		asciiParticle.gameObject.SetActive(value: true);
		asciiParticle.Reset();
		return asciiParticle;
	}

	public static void RecycleParticle(AsciiParticle particle)
	{
		AsciiParticle asciiParticle = particle.prefab;
		if (asciiParticle == null)
		{
			Utils.LogError("particle was not initialized properly and therefore cannot be recycled. ", particle.gameObject);
			return;
		}
		particle.gameObject.SetActive(value: false);
		if (particlePool.ContainsKey(asciiParticle))
		{
			List<AsciiParticle> list = particlePool[asciiParticle];
			if (list.Contains(particle))
			{
				Utils.LogError("particle is already in the pool and therefore cannot be recycled twice.", particle.gameObject);
			}
			else
			{
				list.Add(particle);
			}
		}
		else
		{
			List<AsciiParticle> list2 = new List<AsciiParticle>();
			list2.Add(particle);
			particlePool.Add(asciiParticle, list2);
		}
	}

	public static void DestroyAll()
	{
		foreach (KeyValuePair<AsciiParticle, List<AsciiParticle>> item in particlePool)
		{
			List<AsciiParticle> value = item.Value;
			for (int i = 0; i < value.Count; i++)
			{
				UnityEngine.Object.Destroy(value[i].gameObject);
			}
			value.Clear();
		}
		particlePool.Clear();
	}

	public static void DestroyOld(double ageInSeconds = 10.0)
	{
		List<AsciiParticle> list = new List<AsciiParticle>();
		DateTime now = DateTime.Now;
		foreach (KeyValuePair<AsciiParticle, List<AsciiParticle>> item in particlePool)
		{
			List<AsciiParticle> value = item.Value;
			for (int i = 0; i < value.Count; i++)
			{
				AsciiParticle asciiParticle = value[i];
				if ((now - asciiParticle.timestamp).TotalSeconds >= ageInSeconds)
				{
					list.Add(asciiParticle);
				}
			}
			for (int j = 0; j < list.Count; j++)
			{
				AsciiParticle asciiParticle2 = list[j];
				value.Remove(asciiParticle2);
				UnityEngine.Object.Destroy(asciiParticle2.gameObject);
			}
			list.Clear();
		}
	}
}
