using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using Timberborn.BaseComponentSystem;
using Timberborn.Characters;
using Timberborn.EntitySystem;
using Timberborn.MortalComponents;
using Timberborn.NeedSystem;
using UnityEngine;

namespace Timberborn.Healthcare
{
	internal class BeaverNeedShaderPropertySetter : BaseComponent, IAwakableComponent, IDeadNeededComponent, IInitializableEntity
	{
		private CharacterMaterialModifier _characterMaterialModifier;

		private BeaverNeedShaderPropertySetterSpec _beaverNeedShaderPropertySetterSpec;

		private Dictionary<BeaverNeedShaderPropertySet, int> _propertyIds;

		public void Awake()
		{
			_characterMaterialModifier = GetComponent<CharacterMaterialModifier>();
			_beaverNeedShaderPropertySetterSpec = GetComponent<BeaverNeedShaderPropertySetterSpec>();
			_propertyIds = _beaverNeedShaderPropertySetterSpec.PropertySets.ToDictionary((BeaverNeedShaderPropertySet s) => s, (BeaverNeedShaderPropertySet s) => Shader.PropertyToID(s.PropertyName));
			GetComponent<NeedManager>().NeedChangedActiveState += OnNeedChangedActiveState;
		}

		public void InitializeEntity()
		{
			UpdateAllParameters();
		}

		private void OnNeedChangedActiveState(object sender, NeedChangedActiveStateEventArgs e)
		{
			ImmutableArray<BeaverNeedShaderPropertySet>.Enumerator enumerator = _beaverNeedShaderPropertySetterSpec.PropertySets.GetEnumerator();
			while (enumerator.MoveNext())
			{
				BeaverNeedShaderPropertySet current = enumerator.Current;
				if (e.NeedSpec.Id == current.NeedId)
				{
					UpdateParameter(current, e.IsActive);
				}
			}
		}

		private void UpdateAllParameters()
		{
			ImmutableArray<BeaverNeedShaderPropertySet>.Enumerator enumerator = _beaverNeedShaderPropertySetterSpec.PropertySets.GetEnumerator();
			while (enumerator.MoveNext())
			{
				BeaverNeedShaderPropertySet current = enumerator.Current;
				bool isNeedActive = GetComponent<NeedManager>().NeedIsActive(current.NeedId);
				UpdateParameter(current, isNeedActive);
			}
		}

		private void UpdateParameter(BeaverNeedShaderPropertySet propertySet, bool isNeedActive)
		{
			_characterMaterialModifier.SetFloat(_propertyIds[propertySet], isNeedActive ? 1 : 0);
		}
	}
}
