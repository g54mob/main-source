using Timberborn.BaseComponentSystem;
using Timberborn.Coordinates;
using Timberborn.EntitySystem;
using Timberborn.TemplateInstantiation;
using UnityEngine;

namespace Timberborn.BlockSystem
{
	public class BlockObjectFactory
	{
		private readonly EntityService _entityService;

		private readonly TemplateInstantiator _templateInstantiator;

		public BlockObjectFactory(EntityService entityService, TemplateInstantiator templateInstantiator)
		{
			_entityService = entityService;
			_templateInstantiator = templateInstantiator;
		}

		public BlockObject CreateUnfinished(BlockObjectSpec template, Placement placement)
		{
			BlockObject component = _entityService.Instantiate(template.Blueprint).GetComponent<BlockObject>();
			component.Reposition(placement);
			return component;
		}

		public BlockObject CreateFinished(BlockObjectSpec template, Placement placement)
		{
			BlockObject blockObject = CreateUnfinished(template, placement);
			blockObject.MarkAsFinished();
			return blockObject;
		}

		public BlockObject CreateAsPreview(BlockObjectSpec template, Transform parent, Placement placement)
		{
			BlockObject componentSlow = _templateInstantiator.Instantiate(template.Blueprint, parent).GetComponentSlow<BlockObject>();
			componentSlow.MarkAsPreview();
			componentSlow.Reposition(placement);
			return componentSlow;
		}
	}
}
