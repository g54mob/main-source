using System;
using System.Collections;
using DistantLands.Cozy.Data;
using UnityEngine;

namespace DistantLands.Cozy
{
	[Serializable]
	public class WeatherRelation
	{
		[Range(0f, 1f)]
		public float weight;

		public WeatherProfile profile;

		public bool transitioning = true;

		public IEnumerator Transition(float value, float time)
		{
			transitioning = true;
			float t = 0f;
			float start = weight;
			for (; t < time; t += Time.deltaTime)
			{
				float div = t / time;
				yield return new WaitForEndOfFrame();
				weight = Mathf.Lerp(start, value, div);
			}
			weight = value;
			transitioning = false;
		}
	}
}
