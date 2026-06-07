using System.Collections;
using Bolt;
using DV.Game.Tutorial;
using DV.UI;
using DV.UIFramework;
using DV.Utils;
using Ludiq;
using UnityEngine.UI;

[TypeIcon(typeof(Text))]
[UnitTitle("Show Dialog")]
[UnitSubtitle("Negative message and port are optional")]
[UnitCategory("UI")]
public class ShowDialogUnit : Unit
{
	[DoNotSerialize]
	public ControlInput inputTrigger;

	[DoNotSerialize]
	public ControlOutput confirmTrigger;

	[DoNotSerialize]
	public ControlOutput cancelTrigger;

	[DoNotSerialize]
	[LocalizedValue]
	public ValueInput dialogMessage;

	[LocalizedValue]
	[DoNotSerialize]
	public ValueInput positiveButton;

	[DoNotSerialize]
	[LocalizedValue]
	public ValueInput negativeButton;

	[DoNotSerialize]
	public ValueInput customDialogPrefab;

	protected override void Definition()
	{
		confirmTrigger = ControlOutput("Positive");
		cancelTrigger = ControlOutput("Negative");
		dialogMessage = ValueInput("Message", string.Empty);
		positiveButton = ValueInput("Positive label", string.Empty);
		negativeButton = ValueInput("Negative label", string.Empty);
		customDialogPrefab = ValueInput<Popup>("Custom dialog", null);
		inputTrigger = ControlInputCoroutine("Input", Routine);
		Requirement(dialogMessage, inputTrigger);
		Requirement(positiveButton, inputTrigger);
	}

	private IEnumerator Routine(Flow flow)
	{
		string value = flow.GetValue<string>(dialogMessage);
		string value2 = flow.GetValue<string>(positiveButton);
		string value3 = flow.GetValue<string>(negativeButton);
		flow.stack.AsReference();
		bool confirmed = false;
		bool canceled = false;
		Popup value4 = flow.GetValue<Popup>(customDialogPrefab);
		if ((bool)value4)
		{
			SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.PopupManager.ShowPopup(value4).Closed += delegate(PopupResult result)
			{
				if (result.closedBy == PopupClosedByAction.Positive)
				{
					confirmed = true;
				}
				else
				{
					canceled = true;
				}
			};
			while (!confirmed && !canceled)
			{
				yield return null;
			}
			if (confirmed)
			{
				yield return confirmTrigger;
			}
			else
			{
				yield return cancelTrigger;
			}
		}
		else
		{
			SingletonBehaviour<TutorialHelper>.Instance.ShowDialog(value, value2, value3, delegate
			{
				confirmed = true;
			}, delegate
			{
				canceled = true;
			});
			while (!confirmed && !canceled)
			{
				yield return null;
			}
			if (confirmed)
			{
				yield return confirmTrigger;
			}
			else
			{
				yield return cancelTrigger;
			}
		}
	}
}
