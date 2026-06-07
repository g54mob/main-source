using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ModApi.Planet
{
	[Serializable]
	public class PlanetCubemapSet
	{
		[SerializeField]
		private List<PlanetCubemap> _cubemaps;

		private List<PlanetCubemap> _cubemapsToUnload;

		[SerializeField]
		private int[] _refCounts;

		[SerializeField]
		private List<PlanetCubemapsRequest> _requests;

		public IReadOnlyList<PlanetCubemap> Cubemaps => _cubemaps;

		public PlanetCubemapManager Manager { get; }

		[field: SerializeField]
		public int MaxSize { get; }

		[field: SerializeField]
		public int MinSize { get; }

		[field: SerializeField]
		public IPlanetData PlanetData { get; }

		public IReadOnlyList<PlanetCubemapsRequest> Requests => _requests;

		public bool RequestsUpdated { get; set; }

		public PlanetCubemapSet(PlanetCubemapManager manager, List<PlanetCubemap> cubemapsToUnload, IPlanetData planetData, int minSize, int maxSize)
		{
			Manager = manager;
			PlanetData = planetData;
			MinSize = minSize;
			MaxSize = maxSize;
			_cubemapsToUnload = cubemapsToUnload;
			_requests = new List<PlanetCubemapsRequest>();
			_cubemaps = new List<PlanetCubemap>();
			for (int num = minSize; num <= maxSize; num *= 2)
			{
				_cubemaps.Add(new PlanetCubemap(planetData, num));
			}
			_refCounts = new int[_cubemaps.Count];
			for (int i = 0; i < _refCounts.Length; i++)
			{
				_refCounts[i] = 0;
			}
			Cubemaps[0].LoadCubemaps();
		}

		public void CancelRequest(PlanetCubemapsRequest request)
		{
			RequestsUpdated = _requests.Remove(request);
		}

		public void OnDestroy()
		{
			foreach (PlanetCubemapsRequest item in _requests.ToList())
			{
				item.Cancel();
			}
			foreach (PlanetCubemap cubemap in _cubemaps)
			{
				cubemap.UnloadCubemaps();
			}
			_requests.Clear();
			_cubemaps.Clear();
		}

		public void ProcessRequests()
		{
			if (!RequestsUpdated)
			{
				return;
			}
			RequestsUpdated = false;
			for (int num = _cubemaps.Count - 1; num >= 0; num--)
			{
				PlanetCubemap planetCubemap = _cubemaps[num];
				_refCounts[num] = 0;
				foreach (PlanetCubemapsRequest request in _requests)
				{
					if (request.RequestedSize == request.CurrentSize)
					{
						if (request.CurrentSize == planetCubemap.Size)
						{
							_refCounts[num]++;
						}
					}
					else if (request.RequestedSize == planetCubemap.Size)
					{
						_refCounts[num]++;
						if (planetCubemap.State == PlanetCubemapLoadState.Loaded)
						{
							request.UpdateCubemaps(planetCubemap);
						}
						else if (planetCubemap.State == PlanetCubemapLoadState.Unloaded)
						{
							planetCubemap.LoadCubemapsAsync(this);
						}
					}
					else
					{
						if (request.RequestedSize <= planetCubemap.Size)
						{
							continue;
						}
						if (request.CurrentSize < planetCubemap.Size)
						{
							if (planetCubemap.State == PlanetCubemapLoadState.Loaded)
							{
								_refCounts[num]++;
								request.UpdateCubemaps(planetCubemap);
							}
						}
						else if (request.CurrentSize == planetCubemap.Size)
						{
							_refCounts[num]++;
						}
					}
				}
				if (planetCubemap.State == PlanetCubemapLoadState.Loaded)
				{
					if (_cubemapsToUnload.Contains(planetCubemap))
					{
						if (_refCounts[num] > 0)
						{
							_cubemapsToUnload.Remove(planetCubemap);
						}
					}
					else if (_refCounts[num] == 0 && planetCubemap.Size > MinSize)
					{
						_cubemapsToUnload.Add(planetCubemap);
					}
				}
			}
		}

		public PlanetCubemapsRequest RequestCubemaps(string requestName, int size, Action<PlanetCubemapsRequest> onCubemapsUpdated)
		{
			RequestsUpdated = true;
			PlanetCubemapsRequest planetCubemapsRequest = new PlanetCubemapsRequest(requestName, this, size, onCubemapsUpdated);
			_requests.Add(planetCubemapsRequest);
			return planetCubemapsRequest;
		}
	}
}
