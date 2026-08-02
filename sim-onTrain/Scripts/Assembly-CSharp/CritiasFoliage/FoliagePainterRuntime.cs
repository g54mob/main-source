using System;
using System.Collections.Generic;
using UnityEngine;

namespace CritiasFoliage
{
	public struct FoliagePainterRuntime
	{
		private FoliagePainter m_Painter;

		public List<FoliageTypeRuntime> GetFoliageTypes()
		{
			return m_Painter.GetFoliageTypesRuntime();
		}

		public void SetFoliageTypeHue(int typeHash, Color hue)
		{
			m_Painter.SetFoliageTypeHueRuntime(typeHash, hue);
		}

		public Color GetFoliageTypeHue(int typeHash)
		{
			return m_Painter.GetFoliageTypeHueRuntime(typeHash);
		}

		public void SetFoliageTypeColor(int typeHash, Color color)
		{
			m_Painter.SetFoliageTypeColorRuntime(typeHash, color);
		}

		public Color GetFoliageTypeColor(int typeHash)
		{
			return m_Painter.GetFoliageTypeColorRuntime(typeHash);
		}

		public void SetFoliageTypeCastShadow(int typeHash, bool castShadow)
		{
			m_Painter.SetFoliageTypeCastShadowRuntime(typeHash, castShadow);
		}

		public bool GetFoliageTypeCastShadow(int typeHash)
		{
			return m_Painter.GetFoliageTypeCastShadowRuntime(typeHash);
		}

		public void SetFoliageTypeMaxDistance(int typeHash, float maxDistance)
		{
			m_Painter.SetFoliageTypeMaxDistanceRuntime(typeHash, maxDistance);
		}

		public float GetFoliageTypeMaxDistance(int typeHash)
		{
			return m_Painter.GetFoliageTypeMaxDistanceRuntime(typeHash);
		}

		public void RemoveFoliageInstance(Guid guid)
		{
			m_Painter.RemoveFoliageInstanceRuntime(guid);
		}

		public void RemoveFoliageInstance(int typeHash, Guid guid)
		{
			m_Painter.RemoveFoliageInstanceRuntime(typeHash, guid);
		}

		public void RemoveFoliageInstance(int typeHash, Guid guid, Vector3 position)
		{
			m_Painter.RemoveFoliageInstanceRuntime(typeHash, guid, position);
		}

		public void AddFoliageInstance(int typeHash, FoliageInstance instance)
		{
			m_Painter.AddFoliageInstanceRuntime(typeHash, instance);
		}

		private void RemoveFoliageType(int typeHash)
		{
			throw new NotImplementedException();
		}

		private int AddFoliageType(FoliageTypeBuilder builder)
		{
			throw new NotImplementedException();
		}

		private void RemoveFoliageInstances(int typeHash, Vector3 position, float radius = 0.3f)
		{
			throw new NotImplementedException();
		}

		private void WorldOriginRebase(Vector3 offset)
		{
		}

		public FoliagePainterRuntime(FoliagePainter painter)
		{
			m_Painter = painter;
		}
	}
}
