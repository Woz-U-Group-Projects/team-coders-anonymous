var express = require("express");
var router = express.Router();
const sqlite = require("sqlite3").verbose();
var models = require("../models");

/* GET home page. */
router.get("/", function(req, res, next) {
  models.Fruit.findAll().then(fruits => res.json(fruits));
});

router.post("/", function(req, res, next) {
  console.log(req.body);
  let newFruit = new models.Fruit();
  newFruit.name = req.body.name;
  newFruit.save().then(fruit => res.json(fruit));
});

module.exports = router;
