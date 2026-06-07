using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using GameCreator.Runtime.Variables;
using GameCreator.Runtime.VisualScripting;
using UnityEngine;

[Serializable]
[Version(2, 0, 0)]
[Title("Remove GameObject From List")]
[Description("Remove target gameobject from the list if exist.")]
[Parameter("ListVariable", "The list of game object to look for.")]
[Parameter("Target", "The gameobject to remove from ListVariable")]
[Image(typeof(IconListFirst), ColorTheme.Type.Red, typeof(OverlayListVariable))]
[Category("Variables/Remove GameObject From List")]
[Keywords(new string[] { "Collect", "List", "Remove", "Gameobject" })]
public class RemoveGameObjectFromListInstruction : Instruction
{
	[SerializeField]
	private CollectorListVariable m_ListVariable = new CollectorListVariable();

	[SerializeField]
	private PropertyGetGameObject m_target = new PropertyGetGameObject();

	protected override async Task Run(Args args)
	{
		List<object> list = m_ListVariable.Get(args);
		GameObject gameObject = m_target.Get(args);
		for (int i = 0; i < list.Count; i++)
		{
			GameObject gameObject2 = (GameObject)list[i];
			if (gameObject.gameObject.GetInstanceID() == gameObject2.GetInstanceID())
			{
				list.RemoveAt(i);
			}
		}
		m_ListVariable.Fill(list.ToArray(), args);
		await Instruction.DefaultResult;
	}
}
