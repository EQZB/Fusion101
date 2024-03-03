using Cinemachine;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    CinemachineVirtualCamera _camera;

    void Awake() => _camera = GetComponent<CinemachineVirtualCamera>();
    void OnEnable() => NetworkPlayer._playerSpawned += SetCamera;
    void OnDisable() => NetworkPlayer._playerSpawned -= SetCamera;
    void SetCamera(Transform _cameraTransform) => _camera.Follow = _cameraTransform;
}
