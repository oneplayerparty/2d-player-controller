using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class PlayerJumpState : PlayerAbilityState
{
    private int jumpsLeft;
    public PlayerJumpState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
        jumpsLeft = playerData.amountOfJumps;
    }

    public override void Enter()
    {
        base.Enter();
        player.SetVelocityY(playerData.jumpVelocity);
        isAbilityDone = true;
        jumpsLeft--;
        player.InAirState.SetIsJumping();
    }

    public bool CanJump() => jumpsLeft > 0;

    public void ResetJumps() => jumpsLeft = playerData.amountOfJumps;

    public void DecreaseJumpsLeft() => jumpsLeft--;
}
