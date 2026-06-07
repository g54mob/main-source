using System.Linq;
using Bolt;
using DV.Customization;
using DV.Customization.Gadgets;
using DV.Utils;
using Ludiq;
using UnityEngine;

namespace DV.Tutorial
{
	public class FillHolesUnit : GenericWaitForConditionWithMessage
	{
		private class Context
		{
			public DV.Customization.Customization Target;

			public Collider CurrentHole;

			public string[] RestrictionNamesBackup;

			public GameObject[] RestrictionInstancesBackup;
		}

		[DoNotSerialize]
		public ValueInput targetItem;

		[DoNotSerialize]
		public ValueInput toolReference;

		protected override string AnchorFieldName => string.Empty;

		protected override void InternalDefinition()
		{
			targetItem = ValueInput<GameObject>("Target", null);
			toolReference = ValueInput<GameObject>("Tool", null);
		}

		public override object PrepareContext(Flow flow)
		{
			Context context = new Context();
			context.Target = flow.GetValue<GameObject>(targetItem).GetComponent<DV.Customization.Customization>();
			context.CurrentHole = ((context.Target.HoleCount > 0) ? context.Target.Holes.First() : null);
			return context;
		}

		public override void Initialize(Flow flow, object context, bool silent = false)
		{
			base.Initialize(flow, context, silent);
			Context obj = (Context)context;
			obj.RestrictionNamesBackup = SingletonBehaviour<GadgetSystemUtility>.Instance.AllowedGadgetNames;
			obj.RestrictionInstancesBackup = SingletonBehaviour<GadgetSystemUtility>.Instance.AllowedGadgetInstances;
			SingletonBehaviour<GadgetSystemUtility>.Instance.AllowedGadgetNames = null;
			SingletonBehaviour<GadgetSystemUtility>.Instance.AllowedGadgetInstances = new GameObject[1] { flow.GetValue<GameObject>(toolReference) };
		}

		public override void Deinitialize(Flow flow, object context, bool silent = false)
		{
			base.Deinitialize(flow, context, silent);
			Context context2 = (Context)context;
			SingletonBehaviour<GadgetSystemUtility>.Instance.AllowedGadgetNames = context2.RestrictionNamesBackup;
			SingletonBehaviour<GadgetSystemUtility>.Instance.AllowedGadgetInstances = context2.RestrictionInstancesBackup;
		}

		protected override GameObject GetMessageAnchor(Flow flow, object context)
		{
			Context context2 = (Context)context;
			if (!context2.CurrentHole)
			{
				return null;
			}
			return context2.CurrentHole.gameObject;
		}

		public override bool CheckCondition(Flow flow, object context, bool silent = false)
		{
			Context context2 = (Context)context;
			Collider collider = ((context2.Target.HoleCount > 0) ? context2.Target.Holes.First() : null);
			if (collider != context2.CurrentHole)
			{
				context2.CurrentHole = collider;
				if ((bool)context2.CurrentHole && !silent)
				{
					UpdateMessage(flow, context);
				}
			}
			return context2.Target.HoleCount == 0;
		}
	}
}
