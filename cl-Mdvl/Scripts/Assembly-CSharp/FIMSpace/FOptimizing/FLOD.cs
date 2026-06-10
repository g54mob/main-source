using UnityEngine;

namespace FIMSpace.FOptimizing
{
	public static class FLOD
	{
		public static void AssignDefaultNearestParams(ILODInstance flod)
		{
			flod.Name = "Nearest";
		}

		public static void AssignDefaultCulledParams(ILODInstance flod)
		{
			flod.Disable = true;
			flod.Name = "Culled";
		}

		public static void AssignDefaultHiddenParams(ILODInstance flod)
		{
			flod.Disable = true;
			flod.Name = "Hidden";
		}

		public static void ApplyEnableDisableState(ILODInstance flod, Component component)
		{
			Behaviour behaviour = component as Behaviour;
			if (behaviour != null)
			{
				behaviour.enabled = !flod.Disable;
			}
		}

		public static void DoBaseInterpolation(ILODInstance current, ILODInstance lodA, ILODInstance lodB, float transitionToB)
		{
			current.Disable = BoolTransition(current.Disable, lodA.Disable, lodB.Disable, transitionToB);
		}

		public static float GetValueForLODLevel(float from, float to, float lodLevel, float lodLevels)
		{
			return Mathf.Lerp(from, to, (lodLevel + 1f) / lodLevels);
		}

		public static bool BoolTransition(bool defaultV, bool a, bool b, float transition)
		{
			if (!b && a)
			{
				return false;
			}
			if (transition >= 1f)
			{
				return b;
			}
			if (transition <= 0f)
			{
				return a;
			}
			return defaultV;
		}

		public static object ObjectTransition(object defaultV, object a, object b, float transition)
		{
			if (transition >= 1f)
			{
				return b;
			}
			if (transition <= 0f)
			{
				return a;
			}
			return defaultV;
		}

		public static Texture GetIcon(Component comp, ILODInstance lod)
		{
			if (lod.Icon != null)
			{
				return lod.Icon;
			}
			_ = comp == null;
			return null;
		}
	}
}
