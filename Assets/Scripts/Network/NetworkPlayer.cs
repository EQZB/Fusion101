using System;
using Fusion;
using UnityEngine;

public class NetworkPlayer : NetworkBehaviour
{
    NetworkCharacterControllerPrototype _cc;
    NetworkObject _no;
    
    [SerializeField]
    Transform _cameraTarget;
    
    public static event Action<Transform> _playerSpawned;
    void Awake()
    {
        _cc = GetComponent<NetworkCharacterControllerPrototype>();
        _no = GetComponent<NetworkObject>();
    }

    public override void Spawned()
    {
        if (!_no.HasInputAuthority) return;
        _playerSpawned?.Invoke(_cameraTarget);
    }
    
    public override void FixedUpdateNetwork()
    {
        if (!GetInput(out NetworkInputData data)) return;
        data.Direction.Normalize();
        _cc.Move(5*data.Direction*Runner.DeltaTime);
    }
}
