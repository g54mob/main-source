using UnityEngine;

[RequireComponent(typeof(ElementGroupSegment))]
public class HybridSegment : MonoBehaviour
{
	private ElementGroupSegment _003CElementGroupSegment_003Ek__BackingField;

	public ElementGroupSegment ElementGroupSegment
	{
		get
		{
			return _003CElementGroupSegment_003Ek__BackingField;
		}
		private set
		{
			_003CElementGroupSegment_003Ek__BackingField = value;
		}
	}

	private void Awake()
	{
		ElementGroupSegment = GetComponent<ElementGroupSegment>();
	}
}
