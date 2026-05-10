using JetBrains.Annotations;
using UnityEngine;

namespace Sisus.Attributes
{
	public interface IComponentModifiedCallbackReceiver<TComponent> where TComponent : Component
	{
		void OnComponentAdded([NotNull] Component attributeHolder, [NotNull] TComponent addedComponent);

		void OnComponentModified([NotNull] Component attributeHolder, [NotNull] TComponent modifiedComponent);
	}
}
