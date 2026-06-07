using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	public class SpotList : TPolymorphicList<Spot>
	{
		[SerializeReference]
		private Spot[] m_Spots;

		public override int Length => m_Spots.Length;

		public SpotList()
		{
			m_Spots = new Spot[1]
			{
				new SpotObjectsInstantiatePrefab()
			};
		}

		public void OnAwake(Hotspot hotspot)
		{
			Spot[] spots = m_Spots;
			foreach (Spot spot in spots)
			{
				if (spot != null && spot.IsEnabled)
				{
					spot.OnAwake(hotspot);
				}
			}
		}

		public void OnStart(Hotspot hotspot)
		{
			Spot[] spots = m_Spots;
			foreach (Spot spot in spots)
			{
				if (spot != null && spot.IsEnabled)
				{
					spot.OnStart(hotspot);
				}
			}
		}

		public void OnUpdate(Hotspot hotspot)
		{
			Spot[] spots = m_Spots;
			foreach (Spot spot in spots)
			{
				if (spot != null && spot.IsEnabled)
				{
					spot.OnUpdate(hotspot);
				}
			}
		}

		public void OnEnable(Hotspot hotspot)
		{
			Spot[] spots = m_Spots;
			foreach (Spot spot in spots)
			{
				if (spot != null && spot.IsEnabled)
				{
					spot.OnEnable(hotspot);
				}
			}
		}

		public void OnDisable(Hotspot hotspot)
		{
			Spot[] spots = m_Spots;
			foreach (Spot spot in spots)
			{
				if (spot != null && spot.IsEnabled)
				{
					spot.OnDisable(hotspot);
				}
			}
		}

		public void OnPointerEnter(Hotspot hotspot)
		{
			Spot[] spots = m_Spots;
			foreach (Spot spot in spots)
			{
				if (spot != null && spot.IsEnabled)
				{
					spot.OnPointerEnter(hotspot);
				}
			}
		}

		public void OnPointerExit(Hotspot hotspot)
		{
			Spot[] spots = m_Spots;
			foreach (Spot spot in spots)
			{
				if (spot != null && spot.IsEnabled)
				{
					spot.OnPointerExit(hotspot);
				}
			}
		}

		public void OnDestroy(Hotspot hotspot)
		{
			Spot[] spots = m_Spots;
			foreach (Spot spot in spots)
			{
				if (spot != null && spot.IsEnabled)
				{
					spot.OnDestroy(hotspot);
				}
			}
		}

		public void OnGizmos(Hotspot hotspot)
		{
			Spot[] spots = m_Spots;
			foreach (Spot spot in spots)
			{
				if (spot != null && spot.IsEnabled)
				{
					spot.OnGizmos(hotspot);
				}
			}
		}
	}
}
