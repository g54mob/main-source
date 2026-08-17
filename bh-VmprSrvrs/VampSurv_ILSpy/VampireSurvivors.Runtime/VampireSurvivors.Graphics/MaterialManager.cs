using System;
using System.Collections.Generic;
using UnityEngine;
using VampireSurvivors.Data;
using Zenject;

namespace VampireSurvivors.Graphics;

public class MaterialManager : IInitializable
{
	private static readonly Dictionary<MaterialType, Material> MaterialsCache;

	public void Initialize()
	{
		LoadAllMaterials();
	}

	public static Material GetMaterial(MaterialType type)
	{
		if (MaterialsCache != null)
		{
			int num = ((Dictionary<System.Int32Enum, object>)(object)MaterialsCache).FindEntry((System.Int32Enum)type);
			if (num < 0)
			{
				return null;
			}
			if (MaterialsCache != null)
			{
				return (Material)((Dictionary<System.Int32Enum, object>)(object)MaterialsCache).get_Item((System.Int32Enum)type);
			}
		}
		return (Material)(object)new NullReferenceException();
	}

	private static void LoadAllMaterials()
	{
		Material value = Resources.Load<Material>("DefaultParticles");
		bool flag = ((Dictionary<System.Int32Enum, object>)(object)MaterialsCache).TryInsert((System.Int32Enum)0, (object)value, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		Material value2 = Resources.Load<Material>("DefaultParticlesAdditive");
		bool flag2 = ((Dictionary<System.Int32Enum, object>)(object)MaterialsCache).TryInsert((System.Int32Enum)1, (object)value2, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		Material value3 = Resources.Load<Material>("DefaultTrailRenderer");
		bool flag3 = ((Dictionary<System.Int32Enum, object>)(object)MaterialsCache).TryInsert((System.Int32Enum)2, (object)value3, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		Material value4 = Resources.Load<Material>("DefaultTrailRendererAdditive");
		bool flag4 = ((Dictionary<System.Int32Enum, object>)(object)MaterialsCache).TryInsert((System.Int32Enum)3, (object)value4, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		Material value5 = Resources.Load<Material>("DefaultVFXSprite");
		bool flag5 = ((Dictionary<System.Int32Enum, object>)(object)MaterialsCache).TryInsert((System.Int32Enum)4, (object)value5, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		Material value6 = Resources.Load<Material>("DefaultVFXSpriteNormal");
		bool flag6 = ((Dictionary<System.Int32Enum, object>)(object)MaterialsCache).TryInsert((System.Int32Enum)19, (object)value6, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		Material value7 = Resources.Load<Material>("ScreenVFXSprite");
		bool flag7 = ((Dictionary<System.Int32Enum, object>)(object)MaterialsCache).TryInsert((System.Int32Enum)18, (object)value7, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		Material value8 = Resources.Load<Material>("DefaultCharacterSprite");
		bool flag8 = ((Dictionary<System.Int32Enum, object>)(object)MaterialsCache).TryInsert((System.Int32Enum)5, (object)value8, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		Material value9 = Resources.Load<Material>("DefaultBlitter");
		bool flag9 = ((Dictionary<System.Int32Enum, object>)(object)MaterialsCache).TryInsert((System.Int32Enum)6, (object)value9, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		Material value10 = Resources.Load<Material>("DefaultBlitterAdditive");
		bool flag10 = ((Dictionary<System.Int32Enum, object>)(object)MaterialsCache).TryInsert((System.Int32Enum)7, (object)value10, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		Material value11 = Resources.Load<Material>("DefaultSprite");
		bool flag11 = ((Dictionary<System.Int32Enum, object>)(object)MaterialsCache).TryInsert((System.Int32Enum)8, (object)value11, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		Material value12 = Resources.Load<Material>("DefaultPentagram");
		bool flag12 = ((Dictionary<System.Int32Enum, object>)(object)MaterialsCache).TryInsert((System.Int32Enum)9, (object)value12, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		Material value13 = Resources.Load<Material>("ScrollableSprite");
		bool flag13 = ((Dictionary<System.Int32Enum, object>)(object)MaterialsCache).TryInsert((System.Int32Enum)10, (object)value13, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		Material value14 = Resources.Load<Material>("ScrollableSpriteAdditive");
		bool flag14 = ((Dictionary<System.Int32Enum, object>)(object)MaterialsCache).TryInsert((System.Int32Enum)11, (object)value14, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		Material value15 = Resources.Load<Material>("ScrollableSpriteLit");
		bool flag15 = ((Dictionary<System.Int32Enum, object>)(object)MaterialsCache).TryInsert((System.Int32Enum)12, (object)value15, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		Material value16 = Resources.Load<Material>("Inversion");
		bool flag16 = ((Dictionary<System.Int32Enum, object>)(object)MaterialsCache).TryInsert((System.Int32Enum)13, (object)value16, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		Material value17 = Resources.Load<Material>("Galaxy");
		bool flag17 = ((Dictionary<System.Int32Enum, object>)(object)MaterialsCache).TryInsert((System.Int32Enum)14, (object)value17, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		Material value18 = Resources.Load<Material>("FourCornerTint");
		bool flag18 = ((Dictionary<System.Int32Enum, object>)(object)MaterialsCache).TryInsert((System.Int32Enum)16, (object)value18, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		Material value19 = Resources.Load<Material>("FourCornerTintAdditive");
		bool flag19 = ((Dictionary<System.Int32Enum, object>)(object)MaterialsCache).TryInsert((System.Int32Enum)15, (object)value19, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		Material value20 = Resources.Load<Material>("DefaultVideo");
		bool flag20 = ((Dictionary<System.Int32Enum, object>)(object)MaterialsCache).TryInsert((System.Int32Enum)17, (object)value20, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		Material value21 = Resources.Load<Material>("DefaultSpriteVariableTintFill");
		bool flag21 = ((Dictionary<System.Int32Enum, object>)(object)MaterialsCache).TryInsert((System.Int32Enum)20, (object)value21, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		Material value22 = Resources.Load<Material>("DefaultSpriteLit");
		bool flag22 = ((Dictionary<System.Int32Enum, object>)(object)MaterialsCache).TryInsert((System.Int32Enum)21, (object)value22, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		Material value23 = Resources.Load<Material>("DefaultSpriteTintHue");
		bool flag23 = ((Dictionary<System.Int32Enum, object>)(object)MaterialsCache).TryInsert((System.Int32Enum)22, (object)value23, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		Material value24 = Resources.Load<Material>("ColourReplacementMaterial");
		bool flag24 = ((Dictionary<System.Int32Enum, object>)(object)MaterialsCache).TryInsert((System.Int32Enum)23, (object)value24, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		Material value25 = Resources.Load<Material>("ScrollPerspective");
		bool flag25 = ((Dictionary<System.Int32Enum, object>)(object)MaterialsCache).TryInsert((System.Int32Enum)24, (object)value25, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
	}

	static MaterialManager()
	{
		Dictionary<MaterialType, Material> materialsCache = new Dictionary<MaterialType, Material>();
		MaterialsCache = materialsCache;
	}
}
