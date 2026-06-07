using Bolt;
using DV.Customization.Gadgets;
using DV.Utils;
using Ludiq;
using UnityEngine;

[UnitTitle("Gadget Mount")]
[UnitSubtitle("Wait for mounting or unmounting of a gadget")]
[UnitCategory("Player")]
[TypeIcon(typeof(BoxCollider))]
public class GadgetMountedStateUnit : GenericWaitForConditionWithMessage
{
	private class Context
	{
		public GadgetBase Gadget;

		public string[] RestrictionNamesBackup;

		public GameObject[] RestrictionInstancesBackup;
	}

	[DoNotSerialize]
	public ValueInput gadget;

	[DoNotSerialize]
	public ValueInput mountedState;

	[DoNotSerialize]
	public ValueInput allowedTools;

	protected override string AnchorFieldName => string.Empty;

	protected override void InternalDefinition()
	{
		gadget = ValueInput<GameObject>("Gadget", null);
		mountedState = ValueInput("Mounted", @default: true);
		allowedTools = ValueInput<GameObject>("Tool", null);
	}

	public override object PrepareContext(Flow flow)
	{
		return new Context
		{
			Gadget = flow.GetValue<GameObject>(gadget).GetComponent<GadgetBase>()
		};
	}

	public override void Initialize(Flow flow, object context, bool silent = false)
	{
		base.Initialize(flow, context, silent);
		Context context2 = (Context)context;
		context2.RestrictionNamesBackup = SingletonBehaviour<GadgetSystemUtility>.Instance.AllowedGadgetNames;
		context2.RestrictionInstancesBackup = SingletonBehaviour<GadgetSystemUtility>.Instance.AllowedGadgetInstances;
		SingletonBehaviour<GadgetSystemUtility>.Instance.AllowedGadgetNames = null;
		SingletonBehaviour<GadgetSystemUtility>.Instance.AllowedGadgetInstances = new GameObject[2]
		{
			context2.Gadget.gameObject,
			flow.GetValue<GameObject>(allowedTools)
		};
	}

	public override void Deinitialize(Flow flow, object context, bool silent = false)
	{
		base.Deinitialize(flow, context, silent);
		Context context2 = (Context)context;
		SingletonBehaviour<GadgetSystemUtility>.Instance.AllowedGadgetNames = context2.RestrictionNamesBackup;
		SingletonBehaviour<GadgetSystemUtility>.Instance.AllowedGadgetInstances = context2.RestrictionInstancesBackup;
	}

	public override bool CheckCondition(Flow flow, object context, bool silent = false)
	{
		return ((Context)context).Gadget.IsLinked == flow.GetValue<bool>(mountedState);
	}

	protected override GameObject GetMessageAnchor(Flow flow, object context)
	{
		return ((Context)context).Gadget.gameObject;
	}
}
