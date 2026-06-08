using KitchenData;
using Platforms;
using Unity.Entities;

namespace Kitchen
{
	public static class EffectHelpers
	{
		public static void AddApplianceEffectComponents(EntityCommandBuffer ecb, Entity e, IEffectPropertySource prop)
		{
			if (prop.EffectRange == null || prop.EffectType == null)
			{
				return;
			}
			ecb.AddComponent(e, default(CAppliesEffect));
			if (prop.EffectCondition == null)
			{
				ecb.AddComponent(e, default(CEffectAlways));
			}
			else if (PlatformSettings.AllowsDynamicVariables)
			{
				ecb.AddComponent(e, (dynamic)prop.EffectCondition);
			}
			else
			{
				IEffectCondition effectCondition = prop.EffectCondition;
				if (!(effectCondition is CEffectAlways component))
				{
					if (!(effectCondition is CEffectWhileBeingUsed component2))
					{
						if (effectCondition is CEffectAtNight component3)
						{
							ecb.AddComponent(e, component3);
						}
						else
						{
							EntityCommandBufferManagedComponentExtensions.AddComponent(ecb, e, prop.EffectCondition);
						}
					}
					else
					{
						ecb.AddComponent(e, component2);
					}
				}
				else
				{
					ecb.AddComponent(e, component);
				}
			}
			if (PlatformSettings.AllowsDynamicVariables)
			{
				ecb.AddComponent(e, (dynamic)prop.EffectRange);
				ecb.AddComponent(e, (dynamic)prop.EffectType);
				return;
			}
			IEffectRange effectRange = prop.EffectRange;
			if (!(effectRange is CEffectRangeGlobal component4))
			{
				if (!(effectRange is CEffectRangeSelf component5))
				{
					if (!(effectRange is CEffectRangeRoom component6))
					{
						if (!(effectRange is CEffectRangeTableSet component7))
						{
							if (!(effectRange is CEffectRangeTiles component8))
							{
								if (effectRange is CEffectRangeDirectional component9)
								{
									ecb.AddComponent(e, component9);
								}
								else
								{
									EntityCommandBufferManagedComponentExtensions.AddComponent(ecb, e, prop.EffectRange);
								}
							}
							else
							{
								ecb.AddComponent(e, component8);
							}
						}
						else
						{
							ecb.AddComponent(e, component7);
						}
					}
					else
					{
						ecb.AddComponent(e, component6);
					}
				}
				else
				{
					ecb.AddComponent(e, component5);
				}
			}
			else
			{
				ecb.AddComponent(e, component4);
			}
			IEffectType effectType = prop.EffectType;
			if (!(effectType is CCabinetModifier component10))
			{
				if (!(effectType is CApplianceSpeedModifier component11))
				{
					if (!(effectType is CAppliesStatus component12))
					{
						if (!(effectType is CTableModifier component13))
						{
							if (effectType is CQueueModifier component14)
							{
								ecb.AddComponent(e, component14);
							}
							else
							{
								EntityCommandBufferManagedComponentExtensions.AddComponent(ecb, e, prop.EffectType);
							}
						}
						else
						{
							ecb.AddComponent(e, component13);
						}
					}
					else
					{
						ecb.AddComponent(e, component12);
					}
				}
				else
				{
					ecb.AddComponent(e, component11);
				}
			}
			else
			{
				ecb.AddComponent(e, component10);
			}
		}

		public static void AddAttachedEffectComponents(EntityCommandBuffer ecb, Entity e, Effect eff)
		{
			if (eff.Properties == null)
			{
				return;
			}
			foreach (IEffectProperty property in eff.Properties)
			{
				if (PlatformSettings.AllowsDynamicVariables)
				{
					ecb.AddComponent(e, (dynamic)property);
				}
				else if (!(property is CDestroyEffectOvernight component))
				{
					if (property is CDestroyAfterTableUsed component2)
					{
						ecb.AddComponent(e, component2);
					}
				}
				else
				{
					ecb.AddComponent(e, component);
				}
			}
		}
	}
}
