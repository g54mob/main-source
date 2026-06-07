using System;
using UnityEngine;

namespace ModApi.Planet
{
	[Serializable]
	public class PlanetCubemapsRequest
	{
		[field: SerializeField]
		public Cubemap CubemapColor { get; private set; }

		[field: SerializeField]
		public Cubemap CubemapNormals { get; private set; }

		[field: SerializeField]
		public int CurrentSize { get; private set; }

		public Action<PlanetCubemapsRequest> OnCubemapsUpdated { get; }

		[field: NonSerialized]
		public PlanetCubemapSet PlanetCubemapSet { get; private set; }

		[field: SerializeField]
		public IPlanetData PlanetData { get; }

		[field: SerializeField]
		public int RequestedSize { get; private set; }

		[field: SerializeField]
		public string RequestName { get; }

		public PlanetCubemapsRequest(string requestName, PlanetCubemapSet cubemapSet, int size, Action<PlanetCubemapsRequest> onCubemapsUpdated)
		{
			RequestName = requestName;
			PlanetCubemapSet = cubemapSet;
			PlanetData = cubemapSet.PlanetData;
			RequestedSize = GetValidSize(size);
			CurrentSize = 0;
			CubemapColor = null;
			CubemapNormals = null;
			OnCubemapsUpdated = onCubemapsUpdated;
		}

		public void Cancel()
		{
			PlanetCubemapSet?.CancelRequest(this);
			PlanetCubemapSet = null;
		}

		public void UpdateCubemaps(PlanetCubemap cubemap)
		{
			UpdateCubemaps(cubemap.Size, cubemap.CubemapColor, cubemap.CubemapNormals);
		}

		public void UpdateCubemaps(int size, Cubemap color, Cubemap normals)
		{
			CurrentSize = size;
			CubemapColor = color;
			CubemapNormals = normals;
			OnCubemapsUpdated?.Invoke(this);
		}

		public void UpdateRequestedSize(int requestedSize)
		{
			requestedSize = GetValidSize(requestedSize);
			bool num = RequestedSize != requestedSize;
			RequestedSize = requestedSize;
			if (num && PlanetCubemapSet != null)
			{
				PlanetCubemapSet.RequestsUpdated = true;
			}
		}

		private int GetValidSize(int size)
		{
			PlanetCubemapSet planetCubemapSet = PlanetCubemapSet;
			if (planetCubemapSet == null)
			{
				return size;
			}
			if (size < planetCubemapSet.MinSize)
			{
				return planetCubemapSet.MinSize;
			}
			int result = size;
			for (int i = 1; i < planetCubemapSet.Cubemaps.Count; i++)
			{
				int size2 = planetCubemapSet.Cubemaps[i].Size;
				if (size < size2)
				{
					break;
				}
				result = size2;
			}
			return result;
		}
	}
}
