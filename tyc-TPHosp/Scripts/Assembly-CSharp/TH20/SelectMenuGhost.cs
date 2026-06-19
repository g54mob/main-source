using I2.Loc;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class SelectMenuGhost : SelectMenuCharacter
	{
		private Character _ghost;

		[SerializeField]
		private TMP_Text _name;

		[SerializeField]
		private TMP_Text _causeOfDeath;

		public override void Setup(Character character, Level level)
		{
			base.Setup(character, level);
			_ghost = character;
		}

		protected override void Update()
		{
			base.Update();
			DeathRecordComponent component = _ghost.GetComponent<DeathRecordComponent>();
			if (component != null)
			{
				_name.text = ScriptLocalization.Menu.Hover_Ghost_Name_CS.Replace("{[NAME]}", _ghost.Name);
				_causeOfDeath.text = component.CauseOfDeath;
			}
		}
	}
}
