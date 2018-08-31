/******/ (function(modules) { // webpackBootstrap
/******/ 	// The module cache
/******/ 	var installedModules = {};
/******/
/******/ 	// The require function
/******/ 	function __webpack_require__(moduleId) {
/******/
/******/ 		// Check if module is in cache
/******/ 		if(installedModules[moduleId]) {
/******/ 			return installedModules[moduleId].exports;
/******/ 		}
/******/ 		// Create a new module (and put it into the cache)
/******/ 		var module = installedModules[moduleId] = {
/******/ 			i: moduleId,
/******/ 			l: false,
/******/ 			exports: {}
/******/ 		};
/******/
/******/ 		// Execute the module function
/******/ 		modules[moduleId].call(module.exports, module, module.exports, __webpack_require__);
/******/
/******/ 		// Flag the module as loaded
/******/ 		module.l = true;
/******/
/******/ 		// Return the exports of the module
/******/ 		return module.exports;
/******/ 	}
/******/
/******/
/******/ 	// expose the modules object (__webpack_modules__)
/******/ 	__webpack_require__.m = modules;
/******/
/******/ 	// expose the module cache
/******/ 	__webpack_require__.c = installedModules;
/******/
/******/ 	// define getter function for harmony exports
/******/ 	__webpack_require__.d = function(exports, name, getter) {
/******/ 		if(!__webpack_require__.o(exports, name)) {
/******/ 			Object.defineProperty(exports, name, {
/******/ 				configurable: false,
/******/ 				enumerable: true,
/******/ 				get: getter
/******/ 			});
/******/ 		}
/******/ 	};
/******/
/******/ 	// getDefaultExport function for compatibility with non-harmony modules
/******/ 	__webpack_require__.n = function(module) {
/******/ 		var getter = module && module.__esModule ?
/******/ 			function getDefault() { return module['default']; } :
/******/ 			function getModuleExports() { return module; };
/******/ 		__webpack_require__.d(getter, 'a', getter);
/******/ 		return getter;
/******/ 	};
/******/
/******/ 	// Object.prototype.hasOwnProperty.call
/******/ 	__webpack_require__.o = function(object, property) { return Object.prototype.hasOwnProperty.call(object, property); };
/******/
/******/ 	// __webpack_public_path__
/******/ 	__webpack_require__.p = "";
/******/
/******/ 	// Load entry module and return exports
/******/ 	return __webpack_require__(__webpack_require__.s = 0);
/******/ })
/************************************************************************/
/******/ ([
/* 0 */
/***/ (function(module, exports, __webpack_require__) {

module.exports = __webpack_require__(1);


/***/ }),
/* 1 */
/***/ (function(module, exports, __webpack_require__) {

"use strict";

Object.defineProperty(exports, "__esModule", { value: true });
const Express = __webpack_require__(2);
const http = __webpack_require__(3);
const path = __webpack_require__(4);
const morgan = __webpack_require__(5);
// Initialize dotenv, to use .env file settings if existing
__webpack_require__(6).config();
// Start the Express webserver
let express = Express();
let port = process.env.port || process.env.PORT || 3007;
express.use(Express.json());
express.use(Express.urlencoded({ extended: true }));
// Add simple logging
express.use(morgan('tiny'));
// Add /scripts and /assets as static folders
express.use('/scripts', Express.static(path.join(__dirname, 'web/scripts')));
express.use('/assets', Express.static(path.join(__dirname, 'web/assets')));
// This is used to prevent your tabs from being embedded in other systems than Microsoft Teams
express.use(function (req, res, next) {
    res.setHeader("Content-Security-Policy", "frame-ancestors teams.microsoft.com *.teams.microsoft.com *.skype.com");
    res.setHeader("X-Frame-Options", "ALLOW-FROM https://teams.microsoft.com/."); // IE11
    return next();
});
// Tabs (protected by the above)
express.use('/\*Tab.html', (req, res, next) => {
    res.sendFile(path.join(__dirname, `web${req.path}`));
});
express.use('/\*Config.html', (req, res, next) => {
    res.sendFile(path.join(__dirname, `web${req.path}`));
});
express.use('/\*Remove.html', (req, res, next) => {
    res.sendFile(path.join(__dirname, `web${req.path}`));
});
express.use('/\*Connector.html', (req, res, next) => {
    res.sendFile(path.join(__dirname, `web${req.path}`));
});
express.use('/\*ConnectorConnected.html', (req, res, next) => {
    res.sendFile(path.join(__dirname, `web${req.path}`));
});
// Fallback
express.use(function (req, res, next) {
    res.removeHeader("Content-Security-Policy");
    res.removeHeader("X-Frame-Options"); // IE11
    return next();
});
// Set default web page
express.use('/', Express.static(path.join(__dirname, 'web/'), {
    index: 'index.html'
}));
// Set the port
express.set('port', port);
// Start the webserver
http.createServer(express).listen(port, (err) => {
    if (err) {
        return console.error(err);
    }
    console.log(`Server running on ${port}`);
});


/***/ }),
/* 2 */
/***/ (function(module, exports) {

module.exports = require("express");

/***/ }),
/* 3 */
/***/ (function(module, exports) {

module.exports = require("http");

/***/ }),
/* 4 */
/***/ (function(module, exports) {

module.exports = require("path");

/***/ }),
/* 5 */
/***/ (function(module, exports) {

module.exports = require("morgan");

/***/ }),
/* 6 */
/***/ (function(module, exports) {

module.exports = require("dotenv");

/***/ })
/******/ ]);
//# sourceMappingURL=server.js.map