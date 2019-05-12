import React, { Component } from 'react';
import logo from './logo.svg';
import './App.css';

const _URL = 'https://24.164.14.197:5001/Residents';

class App extends Component 
{
	constructor(props) 
	{
		super(props);
		this.state = { promise: [], error: null, isLoaded: false, accts: [] };
	}
	 
	componentDidMount()
	{
		fetch(_URL, 
				{
					method : 'POST',		// *GET, POST, PUT, DELETE, etc.
					mode : "no-cors",		// no-cors, cors, *same-origin
					cache: 'no-cache',		// *default, no-cache, reload, force-cache, only-if-cached
					credentials: 'same-origin', 	// include, *same-origin, omit
				//	body: JSON.stringify({text: ''}),
					headers : {
							'Content-Type': 'application/json'
							},
				}
			)
		.then(
				// Handle the Promise.
				(response) => {
					this.setState({ promise: response.status });
					console.log(response.status);
				}
			)
		.then(
				// Handle the result
				(result) => {
					this.setState({ isLoaded: true, accts: result });
					console.log("Result: "+result);
				},
				// Handle an Error
				(_Error1) => {
					this.setState({ isLoaded: true, error: _Error1 });
					console.log("Error1: "+_Error1);
				}
			)
		.catch((_Error2) => {
			console.log("Error2: "+_Error2);
		})

	}

	render() 
	{
		const { promise, error, isLoaded, accts } = this.state;
		var _Msg = "Loading ...";

		if(error)
		{
			_Msg = error.message;
		}
		else if(isLoaded)
		{
			_Msg = "";
		}

			return (
				<div className="App">
					<div className="App-header">
						<img src={logo} className="App-logo" alt="logo" />
						<h2>Welcome to SuiteRole React Demo</h2>
					</div>
					<b>Promise: {promise[0]}</b><br />
					<b>{_Msg}</b><br />
					<ol>
						Acct:
						{
							accts[0]
							//accts.map( acct => <li> {acct.id} {acct.firstName1} </li>)
						}
					</ol><br />
					<br />
					<a href="http://24.164.14.197:5000" target="_blank">
						Go to Test OUTPUT.
					</a>
					<div className="App-footer">
						Footer
					</div>
				</div>
			);
	}
}

export default App;


/*
					<p className="App-intro">
						To get started, edit <code>src/App.js</code> and save to reload.
					</p>
*/