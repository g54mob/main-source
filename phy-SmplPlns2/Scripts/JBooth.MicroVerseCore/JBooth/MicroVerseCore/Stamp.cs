using System.Collections.Generic;
using UnityEngine;

namespace JBooth.MicroVerseCore
{
	[ExecuteAlways]
	public class Stamp : MonoBehaviour
	{
		public class KeywordBuilder
		{
			public List<string> keywords = new List<string>(32);

			public List<string> initialKeywords = new List<string>(16);

			private static List<string> kws = new List<string>(64);

			public void Add(string k)
			{
				keywords.Add(k);
			}

			public void Clear()
			{
				keywords.Clear();
			}

			public void ClearInitial()
			{
				initialKeywords.Clear();
			}

			public void Assign(Material mat)
			{
				kws.Clear();
				kws.AddRange(initialKeywords);
				kws.AddRange(keywords);
				mat.shaderKeywords = kws.ToArray();
			}

			public void Remove(string k)
			{
				keywords.Remove(k);
			}
		}

		protected KeywordBuilder keywordBuilder = new KeywordBuilder();

		public int stampVersion;

		public static float terrainReferenceSize = 1000f;

		public virtual void StripInBuild()
		{
			if (Application.isPlaying)
			{
				Object.Destroy(this);
			}
			else
			{
				Object.DestroyImmediate(this);
			}
		}

		public bool IsEnabled()
		{
			if (base.gameObject.activeInHierarchy)
			{
				return base.enabled;
			}
			return false;
		}

		public virtual Bounds GetBounds()
		{
			return new Bounds(Vector3.zero, new Vector3(float.MaxValue, float.MaxValue, float.MaxValue));
		}

		protected void ClearCachedBounds()
		{
		}

		public virtual void OnEnable()
		{
			base.transform.hasChanged = false;
			MicroVerse.instance?.Invalidate(GetBounds());
		}

		public virtual void OnDisable()
		{
			MicroVerse.instance?.Invalidate(GetBounds());
		}

		public virtual FilterSet GetFilterSet()
		{
			return null;
		}

		protected virtual void OnDestroy()
		{
		}

		protected float GetTerrainScalingFactor(Terrain t)
		{
			if (t != null && t.terrainData != null)
			{
				return t.terrainData.size.x / terrainReferenceSize;
			}
			return 1f;
		}
	}
}
