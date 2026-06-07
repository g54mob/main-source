using System.Collections.Generic;
using UnityEngine;

public interface ICritter
{
	int CurrentVariant { get; set; }

	int TextureCount { get; }

	Vector3 InitialScale { get; }

	CritterController.Variant[] Variants { get; }

	string GetTypeName();

	bool ResetPlace();

	float OptimalMinWeather();

	float OptimalMaxWeather();

	float OptimalMinLight();

	float OptimalMaxLight();

	void SetOptionalMesh(bool en);

	List<ICritter> GetGroup();

	void ApplyTexture(int id);

	void Spawn();

	GameObject GetGameObject();

	bool ShouldUpdate();

	bool ShouldDestroy(bool immediate);

	void UpdateMe();

	int GetCount(GameData.EnvironmentType env, GameData.ClimateType cli);

	void InitGroup(List<ICritter> group);

	void SetVisible(bool visible);
}
