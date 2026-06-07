using DV.ModularAudioCar;
using LocoSim.Implementations;
using UnityEngine;

namespace DV.Simulation.Controllers
{
	[RequireComponent(typeof(AudioClipSimReadersController))]
	[RequireComponent(typeof(LayeredAudioSimReadersController))]
	public class SimAudioModule : CarAudioModule
	{
		private LayeredAudioSimReadersController layeredAudioSimReadersController;

		private AudioClipSimReadersController audioClipSimReadersController;

		public override bool ExternalUpdate => false;

		public override void Initialize(TrainCar trainCar)
		{
			if (layeredAudioSimReadersController == null)
			{
				layeredAudioSimReadersController = GetComponent<LayeredAudioSimReadersController>();
			}
			if (audioClipSimReadersController == null)
			{
				audioClipSimReadersController = GetComponent<AudioClipSimReadersController>();
			}
			SimulationFlow simulationFlow = trainCar.SimController?.simFlow;
			if (simulationFlow == null)
			{
				Debug.LogError("Couldn't find simFlow, ignoring SimAudioModule initialization!");
				return;
			}
			layeredAudioSimReadersController.Init(trainCar, simulationFlow);
			audioClipSimReadersController.Init(trainCar, simulationFlow);
		}

		public override void Deinitialize()
		{
			layeredAudioSimReadersController.Deinit();
			audioClipSimReadersController.Deinit();
		}
	}
}
