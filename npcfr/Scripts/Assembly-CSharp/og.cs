using System.Collections.Generic;
using Infrastructure.Project.Services.Tags;
using UnityEngine;
using UnityEngine.EventSystems;

public interface og
{
	bool ftf(out Rigidbody a, out RaycastHit b, float c = 1000f, int d = -1);

	bool fte(out RaycastHit a, float b = 1000f, int c = -1);

	bool ftg(out List<RaycastResult> a, ObjectTag? b = null);
}
