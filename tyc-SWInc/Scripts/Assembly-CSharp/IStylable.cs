using System.Collections.Generic;
using UnityEngine;

public interface IStylable
{
	List<ActorBodyItem> BodyItems { get; set; }

	Transform RootBone { get; set; }

	Dictionary<string, Transform> Rig { get; set; }

	bool UsesLOD1 { get; }

	bool NeedsDestruction { get; }

	Transform GetTransform();

	void UpdateEyes();

	void UpdateHairColor(Color col);

	void UpdateSkinColor(Color col);

	void PostUpdate(bool allowHoliday);

	void SetLOD2Color(string part, Color col);
}
