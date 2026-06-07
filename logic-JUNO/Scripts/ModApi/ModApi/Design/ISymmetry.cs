using System;
using System.Collections.Generic;
using System.Xml.Linq;
using ModApi.Craft;
using ModApi.Craft.Parts;

namespace ModApi.Design
{
	public interface ISymmetry
	{
		void DeleteSymmetricParts(List<IPartScript> partScripts);

		IEnumerable<IPartScript> DuplicateParts(IPartScript rootPart);

		IEnumerable<IPartScript> EnumerateSymmetricPartScripts(IPartScript partScript);

		void ExecuteOnSymmetricPartModifiers<TModifier>(TModifier modifier, bool includeSourceModifier, Action<TModifier> action) where TModifier : PartModifierData;

		void ExecuteOnSymmetricPartModifiers<TModifier, TValue>(TModifier modifier, bool includeSourceModifier, TValue value, Action<TModifier, TValue> action) where TModifier : PartModifierData;

		XElement GenerateSymmetryXml(Assembly assembly);

		T GetSymmetricPartModifier<T>(T sourceModifier, PartData symmetricPart) where T : PartModifierData;

		List<IPartScript> GetSymmetricPartScripts(IPartScript partScript);

		void LoadSymmetryXml(XElement symmetryElement, Assembly assembly);

		void RemovePartConnection(IPartScript partScript, PartConnection partConnection);

		void RemovePartModifier(IPartScript partScript, PartModifierData partModifier);

		void RemoveSymmetryGroup(ISymmetryGroup symmetryGroup);

		void SetSymmetryMode(IPartScript partScript, SymmetryMode symmetryMode, IDesignerUi designerUi);

		void SynchronizePartConnections(IPartScript partScript);

		void SynchronizePartModifiers(IPartScript partScript);

		void SynchronizeParts(IPartScript partScript, bool synchronizeModifiers = false);

		void SynchronizePartStyles(IPartScript partScript, List<IPartScript> symmetricParts);

		void UpdatePartPositions(List<IPartScript> parts);

		void UpdateSymmetry(List<IPartScript> parts, IPartScript partScript, AttachPoint craftAttachPoint);
	}
}
