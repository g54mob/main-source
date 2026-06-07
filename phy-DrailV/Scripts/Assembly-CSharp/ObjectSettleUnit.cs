using Bolt;
using DV.CabControls;
using Ludiq;
using UnityEngine;

[UnitTitle("Object Settle")]
[TypeIcon(typeof(BoxCollider))]
[UnitCategory("Items")]
[UnitSubtitle("Wait for object to slow down to a halt")]
public class ObjectSettleUnit : GenericWaitForCondition
{
	private class Context
	{
		public ItemBase Item;

		public Transform Target;

		public Collider ZoneCollider;

		public float SettlingTime;

		public float SettlingTravelMax;

		public float SettlingRotationMax;

		public Vector3 LastPosition;

		public Quaternion LastRotation;

		public float SettledTime;
	}

	[DoNotSerialize]
	public ValueInput targetObject;

	[DoNotSerialize]
	public ValueInput targetBox;

	[DoNotSerialize]
	public ValueInput settlingTimeInput;

	[DoNotSerialize]
	public ValueInput settlingTravelMax;

	[DoNotSerialize]
	public ValueInput settlingRotationMax;

	protected override void InternalDefinition()
	{
		targetObject = ValueInput<GameObject>("Object", null);
		targetBox = ValueInput<GameObject>("Zone", null);
		settlingTimeInput = ValueInput("Time", 0.5f);
		settlingTravelMax = ValueInput("Position max", 0.05f);
		settlingRotationMax = ValueInput("Rotation max", 1f);
		Requirement(targetObject, inputTrigger);
	}

	public override object PrepareContext(Flow flow)
	{
		Context obj = new Context
		{
			Target = flow.GetValue<GameObject>(targetObject).transform
		};
		obj.Item = obj.Target.GetComponent<ItemBase>();
		obj.ZoneCollider = flow.GetValue<GameObject>(targetBox)?.GetComponent<Collider>();
		obj.SettlingTime = flow.GetValue<float>(settlingTimeInput);
		obj.SettlingTravelMax = flow.GetValue<float>(settlingTravelMax);
		obj.SettlingRotationMax = flow.GetValue<float>(settlingRotationMax);
		obj.LastPosition = obj.Target.position;
		obj.LastRotation = obj.Target.rotation;
		return obj;
	}

	public override bool CheckCondition(Flow flow, object context, bool silent = false)
	{
		if (Time.deltaTime == 0f)
		{
			return false;
		}
		Context context2 = (Context)context;
		Vector3 vector = context2.Target.position;
		if ((bool)context2.Item && context2.Item.IsBoundToPlayer())
		{
			context2.SettledTime = 0f;
			return false;
		}
		if ((bool)context2.ZoneCollider && context2.ZoneCollider.ClosestPoint(vector) != vector)
		{
			context2.SettledTime = 0f;
			return false;
		}
		Quaternion rotation = context2.Target.rotation;
		float num = Vector3.Distance(vector, context2.LastPosition) / Time.deltaTime;
		float num2 = Quaternion.Angle(rotation, context2.LastRotation) / Time.deltaTime;
		context2.LastPosition = vector;
		context2.LastRotation = rotation;
		if (num > context2.SettlingTravelMax || num2 > context2.SettlingRotationMax)
		{
			context2.SettledTime = 0f;
			return false;
		}
		context2.SettledTime += Time.deltaTime;
		return context2.SettledTime >= context2.SettlingTime;
	}
}
