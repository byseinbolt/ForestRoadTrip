using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
   [SerializeField] private WheelCollider _frontRight;
   [SerializeField] private WheelCollider _frontLeft;
   [SerializeField] private WheelCollider _backRight;
   [SerializeField] private WheelCollider _backLeft;

   [SerializeField] private Transform _frontRightTransform;
   [SerializeField] private Transform _frontLeftTransform;
   [SerializeField] private Transform _backRightTransform;
   [SerializeField] private Transform _backLeftTransform;
   
   
   [SerializeField] private float _acceleration = 500f;
   [SerializeField] private float _brakingForce = 600f;
   [SerializeField] private float _maxTurnAngle = 15f;

   private float _currentAcceleration;
   private float _currentBrakingForce;
   private float _currentTurnAngle;

   private void Update()
   {
      _currentAcceleration = _acceleration * Input.GetAxis("Vertical");
      _currentBrakingForce = Input.GetKey(KeyCode.Space) ? _brakingForce : 0f;
      _currentTurnAngle = _maxTurnAngle * Input.GetAxis("Horizontal");
   }

   private void FixedUpdate()
   {
      SpeedUp();
      Brake();
      Turn();
      
      UpdateWheel(_frontRight, _frontRightTransform);
      UpdateWheel(_frontLeft, _frontLeftTransform);
      UpdateWheel(_backRight, _backRightTransform);
      UpdateWheel(_backLeft, _backLeftTransform);
   }


   private void Brake()
   {
      _frontRight.brakeTorque = _currentBrakingForce;
      _frontLeft.brakeTorque = _currentBrakingForce;
      _backRight.brakeTorque = _currentBrakingForce;
      _backLeft.brakeTorque = _currentBrakingForce;
   }

   private void SpeedUp()
   {
      _frontRight.motorTorque = _currentAcceleration;
      _frontLeft.motorTorque = _currentAcceleration;
      _backRight.motorTorque = _currentAcceleration;
      _backLeft.motorTorque = _currentAcceleration;
   }

   private void Turn()
   {
      _frontLeft.steerAngle = _currentTurnAngle;
      _frontRight.steerAngle = _currentTurnAngle;
   }


   private void UpdateWheel(WheelCollider wheelCollider, Transform wheelTransform)
   {
      wheelCollider.GetWorldPose(out var position, out var rotation);
      wheelTransform.position = position;
      wheelTransform.rotation = rotation;
   }
}
