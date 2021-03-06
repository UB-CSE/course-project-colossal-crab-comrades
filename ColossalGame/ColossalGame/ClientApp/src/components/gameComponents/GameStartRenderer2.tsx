﻿import * as React from 'react';
import * as Phaser from 'phaser';
import "./GameStartRenderer.css";
import { connect } from 'react-redux';
import { RouteComponentProps } from 'react-router';
import { ApplicationState, AppThunkAction } from '../../store';
import * as GameDataStore from "../../store/GameData";
import Game from '../../Phaser/Game';
import getCookie from "../../Helpers/GetCookies"



type GameDataProps =
    GameDataStore.GameDataState &
    typeof GameDataStore.actionCreators &
    RouteComponentProps<{}>;

interface GameDataPassedState {
    classChosen3: string
}

//Phaser Variables
var game: Phaser.Game;

class GameStartRenderer2 extends React.PureComponent<GameDataProps, GameDataPassedState> {

    //private classChosen:string;
    constructor(props: any) {
        super(props);
        this.state = {
            classChosen3: props.playerClass as string
        }
        
        
    }
    async componentDidMount() {
        
        const myAsync = async (): Promise<AppThunkAction<GameDataStore.KnownAction> | null > => { //This promise, initializes the signlar connection, then sets the username in the store using the value from the cookie. Then the player is spawned, and finally the phaser game is constructed..
            await this.props.initialize()
            let username = getCookie("username");
            if (username !== null) {
                this.props.setUsername(username);
                console.log("this was the class chosen" + this.state.classChosen3);
                const response = this.props.spawnPlayerAction(this.state.classChosen3); 

                game = new Game(this); //construct the game, passing a reference to this component. This is needed so that the phaser code can call methods from the store.

                return response; //Can probably get rid of this return.
            }
            return null;
        }
        await myAsync();

    }

    public render() {
        return (

            <div id="gameCanvas" />);
    }
};

export default connect(
    (state: ApplicationState) => state.gameData,
    GameDataStore.actionCreators
)(GameStartRenderer2 as any);