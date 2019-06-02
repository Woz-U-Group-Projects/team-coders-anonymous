import React, { Component } from 'react';
import logo from './logo.svg';

import './App.css';
import Residents from './Residents.js';

class App extends Component 
{
	constructor(props) 
	{
		super(props);
		this.state = { promise: [], error: null, isLoaded: false, accts: [] };
	}
	 
	render() 
	{
		return (
			<div className="App">
				<div className="App-header">
					<img src={logo} className="App-logo" alt="logo" />
					<h2>Welcome to SuiteRole React Demo</h2>
				</div>
				<Residents />
				<div className="App-footer">
					Footer
				</div>
			</div>
		);

	}
}

export default App;