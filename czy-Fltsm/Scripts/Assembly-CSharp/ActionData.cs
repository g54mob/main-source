using System;
using I2.Loc;
using UnityEngine;

[Serializable]
public struct ActionData
{
	[SerializeField]
	private Sprite _icon;

	[SerializeField]
	private LocalizedString _label;

	[SerializeField]
	private LocalizedString _description;

	public readonly Sprite Icon => _icon;

	public readonly LocalizedString Label => _label;

	public readonly LocalizedString Description => _description;
}
