using Bolt;
using DV.Common;
using DV.Utils;
using Ludiq;
using UnityEngine;

[UnitTitle("Save Game")]
[UnitSubtitle("Save the game under specified type")]
[UnitCategory("Tutorial")]
[TypeIcon(typeof(ScriptableObject))]
public class SaveGameUnit : Unit
{
	[DoNotSerialize]
	public ControlInput inputTrigger;

	[DoNotSerialize]
	public ValueInput saveType;

	[DoNotSerialize]
	public ValueOutput savedGame;

	[DoNotSerialize]
	public ControlOutput savedTrigger;

	protected override void Definition()
	{
		savedTrigger = ControlOutput("Saved");
		saveType = ValueInput("Type", SaveType.Auto);
		savedGame = ValueOutput<ISaveGame>("Save", null);
		inputTrigger = ControlInput("Input", delegate(Flow flow)
		{
			SaveType value = flow.GetValue<SaveType>(saveType);
			SingletonBehaviour<SaveGameManager>.Instance.StashScreenshot();
			ISaveGame value2 = SingletonBehaviour<SaveGameManager>.Instance.Save(value);
			flow.SetValue(savedGame, value2);
			return savedTrigger;
		});
	}
}
