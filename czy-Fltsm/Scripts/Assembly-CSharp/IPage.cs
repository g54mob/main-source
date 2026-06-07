using System;
using PajamaLlama.SurvivalGuide;
using UnityEngine;

public interface IPage : IComparable<IPage>
{
	string ID { get; }

	string Name { get; }

	Sprite Icon { get; }

	string CompareString { get; }

	void SetIndex(PageIndex index)
	{
	}
}
