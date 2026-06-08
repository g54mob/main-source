using System.Collections.Generic;
using System.Linq;
using Timberborn.BlockSystem;
using Timberborn.Common;
using Timberborn.Coordinates;
using Timberborn.Goods;
using Timberborn.SingletonSystem;
using Timberborn.TemplateSystem;
using UnityEngine;

namespace Timberborn.RecoveredGoodSystem
{
	internal class RecoveredGoodStackFactory : ILoadableSingleton
	{
		private readonly BlockObjectFactory _blockObjectFactory;

		private readonly IRandomNumberGenerator _randomNumberGenerator;

		private readonly TemplateService _templateService;

		private BlockObjectSpec _recoveredGoodStackTemplate;

		public BlockSpec GoodStackBlockSpec { get; private set; }

		public RecoveredGoodStackFactory(BlockObjectFactory blockObjectFactory, IRandomNumberGenerator randomNumberGenerator, TemplateService templateService)
		{
			_blockObjectFactory = blockObjectFactory;
			_randomNumberGenerator = randomNumberGenerator;
			_templateService = templateService;
		}

		public void Load()
		{
			_recoveredGoodStackTemplate = _templateService.GetSingle<RecoveredGoodStackSpec>().GetSpec<BlockObjectSpec>();
			GoodStackBlockSpec = _recoveredGoodStackTemplate.Blocks.Single();
		}

		public void Create(Vector3Int coordinate, IEnumerable<GoodAmount> recoveredGoods)
		{
			RecoveredGoodStack component = _blockObjectFactory.CreateFinished(_recoveredGoodStackTemplate, new Placement(coordinate)).GetComponent<RecoveredGoodStack>();
			component.SetInitialGoods(recoveredGoods);
			RandomizeRotation(component);
		}

		private void RandomizeRotation(RecoveredGoodStack recoveredGoodStack)
		{
			int rotation = _randomNumberGenerator.Range(0, 360);
			recoveredGoodStack.GetComponent<RecoveredGoodStackModel>().SetRotation(rotation);
		}
	}
}
