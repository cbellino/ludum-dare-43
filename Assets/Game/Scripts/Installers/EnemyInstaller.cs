using UnityEngine;
using Zenject;

public class EnemyInstaller : MonoInstaller
{
	[Header("Brain")]
	[SerializeField] private bool _moveTowardsPlayer;
	[SerializeField] private bool _shootAtPlayer;

	[Inject] private Vector3 _initialPosition;
	[Inject] private GameManager _gameManager;

	public override void InstallBindings()
	{
		Container.BindInterfacesAndSelfTo<EnemyFacade>().FromComponentOnRoot();
		Container.Bind<Transform>().FromComponentOnRoot();
		Container.Bind<GameObject>().FromInstance(gameObject);
		Container.BindInterfacesTo<EnemySpawnHandler>().AsSingle();
		Container.BindInstance(_initialPosition).WhenInjectedInto<EnemySpawnHandler>();

		InstallBrain();
	}

	private void InstallBrain()
	{
		Container.Bind<ITarget>().FromInstance(_gameManager.Player);
		Container.Bind<IInputState>().To<InputState>().AsSingle();

		if (_moveTowardsPlayer)
		{
			Container.Bind<IBrainPart>().To<MoveTowardsPlayer>().AsSingle();
		}
		if (_shootAtPlayer)
		{
			Container.Bind<IBrainPart>().To<ShootAtPlayer>().AsSingle();
		}
	}
}