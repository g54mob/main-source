using System;
using NSMedieval.State;
using NSMedieval.StatsSystem;
using UnityEngine;

namespace NSMedieval.Goap
{
	public interface IProductionAgent : IStorageAgent, IGameDisposable, IDisposable
	{
		bool IsProducing { get; set; }

		bool SkillIsBlocked(SkillType skill);

		int GetSkillLevel(SkillType skill);

		AttributeInstance GetAttribute(AttributeType attribute);

		float GetAttributeValue(AttributeType stat);

		void AddExperience(SkillType skill, float amount, bool isSilent = false);

		void FaceObject(Vector3 position);

		void FaceObject(Transform transform);

		void LookAt(Transform transform);

		void SetEulerAngle(Vector3 eulerAngle);
	}
}
