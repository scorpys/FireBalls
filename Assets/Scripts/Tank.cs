using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour
{
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private float _delayBetweenShoots;
    [SerializeField] private float _recoilDistance;
    [SerializeField] private Bullet[] _bulletTemplates;

    private float _timeAfterShoot;

    private void Update()
    {
        _timeAfterShoot += Time.deltaTime;

        if (Input.GetMouseButton(0))
        {
            if(_timeAfterShoot > _delayBetweenShoots)
            {
                Shoot();
                transform.DOMoveZ(transform.position.z - _recoilDistance, _delayBetweenShoots / 2).SetLoops(2, LoopType.Yoyo);
                _timeAfterShoot = 0;
            }
        }
    }

    private void Shoot()
    {
        var bullet = _bulletTemplates[Random.Range(0, _bulletTemplates.Length)];
        Instantiate(bullet, _shootPoint.position, Quaternion.identity);
    }
}
