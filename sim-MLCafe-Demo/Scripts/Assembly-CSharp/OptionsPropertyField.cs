using UnityEngine;
using UnityEngine.Events;

public class OptionsPropertyField<T> : MonoBehaviour
{
	[SerializeField]
	protected T propertyField;

	[SerializeField]
	public UnityEvent<T> OnLoad;

	public void LoadField()
	{
		OnLoad.Invoke(propertyField);
	}
}
